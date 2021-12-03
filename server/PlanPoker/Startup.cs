using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;
using PlanPoker.Domain.Services;
using PlanPoker.Filters;
using PlanPoker.Infrastructure.Repositories;
using PlanPoker.Middlewares;
using PlanPoker.Models;
using PlanPoker.Repositories;
using PlanPoker.Services;

namespace PlanPoker
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      this.Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      var mvcBuilder = services.AddControllers();

      mvcBuilder.Services.Configure((MvcOptions options) =>
      {
        options.Filters.Add<ExceptionFilter>();
      });

      services
        .AddHttpContextAccessor()
        .AddSwaggerGen()
        .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie();

      services
        .AddSingleton<IRepository<ExampleEntity>, ExampleRepository>()
        .AddSingleton<IRepository<Login>, LoginRepository>()
        .AddScoped<AuthenticationService>()
        .AddTransient<ExampleService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseDeveloperExceptionPage();
      }

      app
        .UseAuthentication()
        .UseAuthenticationService()
        .UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
