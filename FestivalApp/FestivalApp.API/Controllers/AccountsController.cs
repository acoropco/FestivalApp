using FestivalApp.Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FestivalApp.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [AllowAnonymous]
  public class AccountsController : ControllerBase
  {
    private readonly UserManager<User> _userManager;

    public AccountsController(UserManager<User> userManager)
    {
      _userManager = userManager;
    }
  }
}