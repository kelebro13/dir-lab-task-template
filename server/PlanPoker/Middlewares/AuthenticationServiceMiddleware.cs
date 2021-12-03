using System;
using Microsoft.AspNetCore.Builder;
using PlanPoker.Services;

namespace PlanPoker.Middlewares
{
  public static class AuthenticationServiceMiddleware
  {
    public static IApplicationBuilder UseAuthenticationService(this IApplicationBuilder app)
    {
      return app.Use((context, next) =>
      {
        var id = context.User.Identity?.Name;
        if (id is not null)
          AuthenticationService.CurrentUserId = Guid.Parse(id);

        return next.Invoke();
      });
    }
  }
}
