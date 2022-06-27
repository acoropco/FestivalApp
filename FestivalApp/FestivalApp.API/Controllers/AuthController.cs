using AutoMapper;
using FestivalApp.API.DTOs;
using FestivalApp.Core.Interfaces;
using FestivalApp.Core.Models;
using FestivalApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FestivalApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailMessageProvider _emailMessageProvider;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        private readonly IEmailSender _emailSender;

        private const string RegisterEmailSubject = "Email Confirmation Token";
        private const string ResetPasswordEmailSubject = "Reset password Token";

        public AuthController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IMapper mapper,
            IConfiguration config,
            IEmailMessageProvider emailMessageProvider,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _config = config;
            _emailMessageProvider = emailMessageProvider;
            _emailSender = emailSender;
        }

        private async Task<string> GenerateToken(User user)
        {
            var claims = new List<Claim> {
                new Claim (ClaimTypes.NameIdentifier, user.Id.ToString()),
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
            var userEntity = _mapper.Map<User>(userForRegisterDto);
            userEntity.Created = DateTime.Now;
            userEntity.Email = userEntity.UserName;

            var result = await _userManager.CreateAsync(userEntity, userForRegisterDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(userEntity);
            var emailMessageConfig = new EmailMessageConfiguration
            {
                Token = token,
                EmailParam = userEntity.Email,
                EmailTo = new List<string> { userEntity.Email },
                ClientURI = userForRegisterDto.ClientURI,
                Subject = RegisterEmailSubject
            };

            var message = _emailMessageProvider.GenerateEmailMessage(emailMessageConfig);

            await _emailSender.SendEmailAsync(message);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var user = await _userManager.FindByNameAsync(userForLoginDto.Username);

            if (user == null)
            {
                return Unauthorized("Invalid authorization!");
            }

            if (!await _userManager.IsEmailConfirmedAsync(user))
            {
                return Unauthorized("Email is not confirmed!");
            }

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
            {
                return BadRequest("Invalid Email Confirmation Request");
            }

            var confirmResult = await _userManager.ConfirmEmailAsync(user, token);

            if (!confirmResult.Succeeded)
            {
                return BadRequest("Invalid Email Confirmation Request");
            }

            return Ok();
        }

        [HttpPost("forgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto forgotPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);

            if (user == null)
            {
                return Ok("An email has been sent to this address.");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var emailMessageConfig = new EmailMessageConfiguration
            {
                Token = token,
                EmailParam = forgotPasswordDto.Email,
                EmailTo = new List<string> { user.Email },
                ClientURI = forgotPasswordDto.ClientURI,
                Subject = ResetPasswordEmailSubject
            };

            var message = _emailMessageProvider.GenerateEmailMessage(emailMessageConfig);

            await _emailSender.SendEmailAsync(message);

            return Ok();
        }

        [HttpPost("resetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);

            if (user == null)
            {
                return BadRequest("Invalid Request");
            }

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