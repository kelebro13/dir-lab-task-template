using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlanPoker.DTO;
using PlanPoker.Services;

namespace PlanPoker.Controllers
{
  [ApiController]
  [Route("api/[controller]/[action]")]
  public class LoginController : ControllerBase
  {
    private readonly AuthenticationService authenticationService;

    public LoginController(AuthenticationService authenticationService)
    {
      this.authenticationService = authenticationService;
    }

    [HttpPost]
    public async Task<Guid?> Login(LoginDTO loginDTO)
    {
      var login = await this.authenticationService.Authenticate(loginDTO);
      return login?.User;
    }

    [HttpGet]
    public Task Logout()
    {
      return this.authenticationService.SignOut();
    }
  }
}
