using AutoMapper;
using FestivalApp.API.Attributes;
using FestivalApp.API.DTOs;
using FestivalApp.Core.Interfaces;
using FestivalApp.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using IQueryProvider = FestivalApp.Core.Interfaces.IQueryProvider;

namespace FestivalApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IQueryProvider _queryProvider;
        private readonly ICommandProvider _commandProvider;

        public RentalsController(IMapper mapper, IMediator mediator, IQueryProvider queryProvider, ICommandProvider commandProvider)
        {
            _mapper = mapper;
            _mediator = mediator;
            _queryProvider = queryProvider;
            _commandProvider = commandProvider;
        }

        [HttpPost("{userId}")]
        [AuthorizeUser]
        public async Task<IActionResult> AddRental(int userId, RentalForCreationDto rentalForCreationDto)
        {
            var rental = _mapper.Map<RentalModel>(rentalForCreationDto);

            var command = _commandProvider.AddRentalCommand(userId, rental);

            var result = await _mediator.Send(command);

            return CreatedAtRoute("GetRental", new { id = result }, result);
        }

        [HttpGet("getRental/{id}", Name = "GetRental")]
        public async Task<ActionResult<RentalModel>> GetRental(int id)
        {
            var query = _queryProvider.GetRentalByIdQuery(id);

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<RentalModel>>> GetRentals()
        {
            var query = _queryProvider.GetRentalsQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}