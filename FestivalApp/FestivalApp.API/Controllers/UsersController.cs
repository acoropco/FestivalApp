using AutoMapper;
using FestivalApp.API.Attributes;
using FestivalApp.API.DTOs;
using FestivalApp.Core.Interfaces;
using FestivalApp.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using IQueryProvider = FestivalApp.Core.Interfaces.IQueryProvider;

namespace FestivalApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IQueryProvider _queryProvider;
        private readonly ICommandProvider _commandProvider;

        public UsersController(IMediator mediator, IMapper mapper, IQueryProvider queryProvider, ICommandProvider commandProvider)
        {
            _mediator = mediator;
            _mapper = mapper;
            _queryProvider = queryProvider;
            _commandProvider = commandProvider;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserProfileDto>> GetUser(int id)
        {
            var query = _queryProvider.GetUserByIdQuery(id);

            var result = await _mediator.Send(query);

            return Ok(_mapper.Map<UserProfileDto>(result));
        }

        [HttpPatch("{userId}")]
        [AuthorizeUser]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUser(int userId, UserEditDto userEditDto)
        {
            var userUpdateModel = _mapper.Map<UserUpdateModel>(userEditDto);

            var command = _commandProvider.UpdateUserCommand(userId, userUpdateModel);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}