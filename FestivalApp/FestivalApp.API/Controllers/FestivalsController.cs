using AutoMapper;
using FestivalApp.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using IQueryProvider = FestivalApp.Core.Interfaces.IQueryProvider;
using FestivalApp.Core.Models;
using FestivalApp.API.DTOs;
using FestivalApp.API.Attributes;

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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<FestivalModel>>> GetFestivals()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var query = _queryProvider.GetFestivalsQuery(userId);

            var result = await _mediator.Send(query);

            return Ok(_mapper.Map<List<FestivalModel>, List<FestivalDetailsDto>>(result));
        }

        // TODO update endpoint based on further development
        [HttpGet("getFestival/{id}", Name = "GetFestival")]
        public async Task<ActionResult<FestivalDetailsDto>> GetFestival(int id)
        {
            var query = _queryProvider.GetFestivalByIdQuery(id);

            var result = await _mediator.Send(query);

            return Ok(_mapper.Map<FestivalDetailsDto>(result));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> AddFestival([FromBody]FestivalRequestDto festivalRequestDto)
        {
            var festival = _mapper.Map<FestivalModel>(festivalRequestDto);

            var command = _commandProvider.AddFestivalCommand(festival);

            var result = await _mediator.Send(command);

            return CreatedAtRoute("GetFestival", new { id = result }, result);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<FestivalDetailsDto>> UpdateFestival(int id, [FromBody] FestivalRequestDto festivalRequestDto)
        {
            var festival = _mapper.Map<FestivalUpdateModel>(festivalRequestDto);

            var command = _commandProvider.UpdateFestivalCommand(id, festival);

            var result = await _mediator.Send(command);

            return Ok(_mapper.Map<FestivalDetailsDto>(result));
        }

        [HttpPost("{festivalId}/like")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> LikeFestival(int festivalId, int userId)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var command = _commandProvider.LikeFestivalCommand(festivalId, userId);

            await _mediator.Send(command);

            return Ok();
        }

    }
}