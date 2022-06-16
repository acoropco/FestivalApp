using AutoMapper;
using FestivalApp.API.DTOs;
using FestivalApp.Core.Interfaces;
using FestivalApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FestivalApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalsController : ControllerBase
    {
        private readonly IFestivalRepository _repo;
        private readonly IMapper _mapper;

        public RentalsController(IFestivalRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> AddRental(RentalForCreationDto rentalForCreationDto)
        {
            var rental = _mapper.Map<Rental>(rentalForCreationDto);
            rental.Created = DateTime.Now;

            _repo.Add(rental);

            await _repo.SaveAll();

            var rentalForListDto = _mapper.Map<RentalForListDto>(rental);
            return CreatedAtRoute("GetRental", new { id = rentalForListDto.Id }, rentalForListDto);


            throw new Exception("There was an error when adding this rental");
        }

        [HttpGet("{id}", Name = "GetRental")]
        public async Task<IActionResult> GetRental(int id)
        {
            var rental = await _repo.GetRental(id);
            var rentalForList = _mapper.Map<RentalForListDto>(rental);

            return Ok(rentalForList);
        }

        [HttpGet]
        public async Task<IActionResult> GetRentals()
        {
            var rentals = await _repo.GetRentals();
            var rentalsForList = _mapper.Map<IEnumerable<RentalForListDto>>(rentals);

            return Ok(rentalsForList);
        }
    }
}