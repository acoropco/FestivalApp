using AutoMapper;
using FestivalApp.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using IQueryProvider = FestivalApp.Core.Interfaces.IQueryProvider;
using FestivalApp.Core.Models;
using FestivalApp.API.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace FestivalApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
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
        public async Task<ActionResult<List<FestivalModel>>> GetFestivals(int userId)
        {
            var query = _queryProvider.GetFestivalsQuery(userId);

            var result = await _mediator.Send(query);

            return Ok(_mapper.Map<List<FestivalModel>, List<FestivalForListDto>>(result));
        }

        [HttpGet("getFestival/{id}", Name = "GetFestival")]
        public async Task<IActionResult> GetFestival(int id)
        {
            var query = _queryProvider.GetFestivalByIdQuery(id);

            var result = await _mediator.Send(query);

            return Ok(_mapper.Map<FestivalModel, FestivalForListDto>(result));
        }

        [HttpPost]
        public async Task<IActionResult> AddFestival(FestivalForCreationDto festivalForCreationDto)
        {
            var festival = _mapper.Map<FestivalModel>(festivalForCreationDto);

            var command = _commandProvider.AddFestivalCommand(festival);

            var result = await _mediator.Send(command);

            return CreatedAtRoute("GetFestival", new { id = result }, result);
        }

        [HttpPost("{festivalId}/like/{userId}")]
        public async Task<IActionResult> LikeFestival(int festivalId, int userId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
            {
                return Unauthorized();
            }

            var command = _commandProvider.LikeFestivalCommand(festivalId, userId);

            await _mediator.Send(command);

            return Ok();
        }

    }
}