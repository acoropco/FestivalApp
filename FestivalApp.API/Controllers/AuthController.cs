using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FestivalApp.API.Dtos;
using FestivalApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FestivalApp.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [AllowAnonymous]
  public class AuthController : ControllerBase
  {
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;

    public AuthController(IMapper mapper, IConfiguration config,
      UserManager<User> userManager, SignInManager<User> signInManager)
    {
      _config = config;
      _mapper = mapper;
      _signInManager = signInManager;
      _userManager = userManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
    {
      var userToCreate = _mapper.Map<User>(userForRegisterDto);
      userToCreate.Email = userToCreate.UserName;

      var result = await _userManager.CreateAsync(userToCreate, userForRegisterDto.Password);

      if (result.Succeeded)
        return Ok();

      return BadRequest(result.Errors);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
    {
      var user = await _userManager.FindByNameAsync(userForLoginDto.Username);
      if (user == null)
        return Unauthorized();

      var result = await _signInManager.CheckPasswordSignInAsync(user, userForLoginDto.Password, false);

      if (result.Succeeded)
      {
        var appUser = _mapper.Map<UserProfileDto>(user);
        return Ok(new
        {
          token = GenerateToken(user).Result, 
          user = appUser
        });
      }

      return Unauthorized();
    }

    private async Task<string> GenerateToken(User user)
    {
      var claims = new List<Claim> {
        new Claim (ClaimTypes.NameIdentifier, user.Id.ToString ()),
        new Claim (ClaimTypes.Name, user.UserName)
      };

      var roles = await _userManager.GetRolesAsync(user);

      foreach (var role in roles)
      {
        claims.Add(new Claim(ClaimTypes.Role, role));
      }

      var key = new SymmetricSecurityKey(Encoding.UTF8
        .GetBytes(_config.GetSection("AppSettings:Token").Value));

      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.Now.AddDays(1),
        SigningCredentials = creds
      };

      var tokenHandler = new JwtSecurityTokenHandler();
      var token = tokenHandler.CreateToken(tokenDescriptor);

      return tokenHandler.WriteToken(token);
    }
  }
}