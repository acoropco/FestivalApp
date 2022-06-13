using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FestivalApp.API.Dtos;
using FestivalApp.API.Helpers;
using FestivalApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
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
    private readonly IEmailSender _emailSender;

    public AuthController(IMapper mapper, IConfiguration config,
      UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender)
    {
      _config = config;
      _mapper = mapper;
      _signInManager = signInManager;
      _emailSender = emailSender;
      _userManager = userManager;
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

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

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

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
    {
      var userToCreate = _mapper.Map<User>(userForRegisterDto);
      userToCreate.Email = userToCreate.UserName;

      var result = await _userManager.CreateAsync(userToCreate, userForRegisterDto.Password);

      if (!result.Succeeded)
        return BadRequest(result.Errors);

      var token = await _userManager.GenerateEmailConfirmationTokenAsync(userToCreate);
      var param = new Dictionary<string, string>
      {
        {"token", token },
        {"email", userToCreate.Email }
      };
      var callback = QueryHelpers.AddQueryString(userForRegisterDto.ClientURI, param);
      var message = new Message(new string[] { userToCreate.Email }, "Email Confirmation token", callback);
      await _emailSender.SendEmailAsync(message);

      return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
    {
      var user = await _userManager.FindByNameAsync(userForLoginDto.Username);
      if (user == null)
        return Unauthorized("Invalid authorization!");

      if (!await _userManager.IsEmailConfirmedAsync(user))
        return Unauthorized("Email is not confirmed!");

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

      return Unauthorized("Invalid authorization!");
    }

    [HttpGet("emailConfirmation")]
    public async Task<IActionResult> EmailConfirmation([FromQuery] string email, [FromQuery] string token)
    {
      var user = await _userManager.FindByEmailAsync(email);
      if (user == null)
        return BadRequest("Invalid Email Confirmation Request");

      var confirmResult = await _userManager.ConfirmEmailAsync(user, token);
      if (!confirmResult.Succeeded)
        return BadRequest("Invalid Email Confirmation Request");
      return Ok();
    }

    [HttpPost("forgotPassword")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
    {
      var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);
      if (user == null)
        return BadRequest("If this address is correct an email has been sent to it.");

      var token = await _userManager.GeneratePasswordResetTokenAsync(user);
      var param = new Dictionary<string, string>
      {
        {"token", token},
        {"email", forgotPasswordDto.Email}
      };

      var callback = QueryHelpers.AddQueryString(forgotPasswordDto.ClientURI, param);
      var message = new Message(new string[] { user.Email }, "Reset password token", callback);

      await _emailSender.SendEmailAsync(message);

      return Ok();
    }

    [HttpPost("resetPassword")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
    {
      if (!ModelState.IsValid)
        return BadRequest();
      var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
      if (user == null)
        return BadRequest("Invalid Request");
      var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.Password);
      if (!resetPassResult.Succeeded)
      {
        var errors = resetPassResult.Errors.Select(e => e.Description);
        return BadRequest(new { Errors = errors });
      }
      return Ok();
    }
  }
}