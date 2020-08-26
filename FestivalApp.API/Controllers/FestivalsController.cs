using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using FestivalApp.API.Data;
using FestivalApp.API.Dtos;
using FestivalApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FestivalApp.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class FestivalsController : ControllerBase
  {
    private readonly IFestivalRepository _repo;
    private readonly IMapper _mapper;
    public FestivalsController(IFestivalRepository repo, IMapper mapper)
    {
      _mapper = mapper;
      _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> GetFestivals()
    {
      var festivalsfromRepo = await _repo.GetFestivals();
      var festivalsForList = _mapper.Map<IEnumerable<FestivalForListDto>>(festivalsfromRepo);

      return Ok(festivalsForList);
    }

    [HttpGet("{id}", Name = "GetFestival")]
    public async Task<IActionResult> GetFestival(int id)
    {
      var festivalFromRepo = await _repo.GetFestival(id);
      var festivalForList = _mapper.Map<FestivalForListDto>(festivalFromRepo);

      return Ok(festivalForList);
    }

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