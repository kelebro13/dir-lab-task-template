using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using PlanPoker.Domain.Repositories;
using PlanPoker.DTO;
using PlanPoker.Models;

namespace PlanPoker.Services
{
  public class AuthenticationService
  {
    /// <remarks>
    /// Пока с солью не заморачиваемся.
    /// </remarks>
    private static readonly byte[] salt = new byte[128 / 8];

    private static readonly ThreadLocal<Guid> currentUserId = new ThreadLocal<Guid>();
    public static Guid CurrentUserId
    {
      get => currentUserId.Value;
      internal set => currentUserId.Value = value;
    }

    private readonly IRepository<Login> loginsRepository;
    private readonly IHttpContextAccessor httpContextAccessor;

    public AuthenticationService(IRepository<Login> loginsRepository, IHttpContextAccessor httpContextAccessor)
    {
      this.loginsRepository = loginsRepository;
      this.httpContextAccessor = httpContextAccessor;
    }

    private static string GetPasswordHash(string password)
    {
      var hash = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA256, 100, 256 / 8);
      return Convert.ToBase64String(hash);
    }

    public async Task<Login> Authenticate(LoginDTO loginDTO)
    {
      var hashedPassword = GetPasswordHash(loginDTO.Password);
      var login = this.loginsRepository.GetAll()
        .Where(l => l.UserName == loginDTO.UserName)
        .FirstOrDefault();

      if (login is null)
      {
        // Если пользователь незарегистрирован - регистрируем нового пользователя.

        // TODO: Создание нового пользователя.
        var userId = Guid.NewGuid();

        login = new Login()
        {
          User = userId,
          UserName = loginDTO.UserName,
          Password = hashedPassword
        };

        this.loginsRepository.Save(login);
      }

      if (login.Password == hashedPassword)
      {
        await this.SignIn(login);
        return login;
      }

      return null;
    }

    private Task SignIn(Login login)
    {
      var claim = new Claim(ClaimsIdentity.DefaultNameClaimType, login.User.ToString());
      var identity = new ClaimsIdentity(new[] { claim }, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
      return this.httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
    }

    public Task SignOut()
    {
      return this.httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
  }
}
