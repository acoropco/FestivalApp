using System;
using System.Threading.Tasks;
using AutoMapper;
using FestivalApp.API.Data;
using FestivalApp.API.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FestivalApp.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UsersController : ControllerBase
  {
    private readonly IFestivalRepository _repo;
    private readonly IMapper _mapper;
    public UsersController(IFestivalRepository repo, IMapper mapper)
    {
      _mapper = mapper;
      _repo = repo;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
      var userFromRepo = await _repo.GetUser(id);

      if (userFromRepo == null)
        return BadRequest();

      var userForProfile = _mapper.Map<UserProfileDto>(userFromRepo);

      return Ok(userForProfile);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, UserEditDto userEditDto)
    {
      var userFromRepo = await _repo.GetUser(id);

      _mapper.Map(userEditDto, userFromRepo);

      if (await _repo.SaveAll())
        return NoContent();

      throw new Exception($"Updating user with id: {id} failed");
    }
  }
}