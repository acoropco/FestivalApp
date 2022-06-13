using AutoMapper;
using FestivalApp.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using IQueryProvider = FestivalApp.Core.Interfaces.IQueryProvider;
using DomainModels = FestivalApp.Core.Models;
using FestivalApp.API.DTOs;

namespace FestivalApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FestivalsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IQueryProvider _queryProvider;
        private readonly ICommandProvider _commandProvider;

        public FestivalsController(IMapper mapper, IMediator mediator, IQueryProvider queryProvider, ICommandProvider commandProvider)
        {
            _mapper = mapper;
            _mediator = mediator;
            _queryProvider = queryProvider;
            _commandProvider = commandProvider;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetFestivals(int userId)
        {
            var query = _queryProvider.GetFestivalsQuery(userId);

            var result = await _mediator.Send(query);

            return Ok(_mapper.Map<List<DomainModels.Festival>, List<FestivalForListDto>>(result));
        }

        // [HttpGet("{id}", Name = "GetFestival")]
        // public async Task<IActionResult> GetFestival(int id)
        // {
        //   var festivalFromRepo = await _repo.GetFestival(id);
        //   var festivalForList = _mapper.Map<FestivalForListDto>(festivalFromRepo);

        //   return Ok(festivalForList);
        // }

        [HttpPost]
        public async Task<IActionResult> AddFestival(FestivalForCreationDto festivalForCreationDto)
        {
            var festival = _mapper.Map<Festival>(festivalForCreationDto);
            _repo.Add(festival);

            if (await _repo.SaveAll())
            {
                var festivalForListDto = _mapper.Map<FestivalForListDto>(festival);
                return CreatedAtRoute("GetFestival", new { id = festival.Id }, festivalForListDto);
            }

            throw new Exception("There was an error when adding this festival");
        }

        [HttpPost("{festivalId}/like/{userId}")]
        public async Task<IActionResult> LikeFestival(int festivalId, int userId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();

            var like = await _repo.GetLike(userId, festivalId);
            var user = await _repo.GetUser(userId);
            var festival = await _repo.GetFestival(festivalId);

            if (user == null || festival == null)
                return NotFound();

            if (like != null)
                _repo.Delete(like);
            else
            {
                like = new UserFestival()
                {
                    User = user,
                    Festival = festival,
                    UserId = userId,
                    FestivalId = festivalId
                };
                _repo.Add<UserFestival>(like);
            }

            if (await _repo.SaveAll())
                return Ok();

            return BadRequest("Failed to Like/Unlike the Festival");
        }

    }
}