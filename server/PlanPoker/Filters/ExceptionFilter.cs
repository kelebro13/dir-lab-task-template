using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PlanPoker.DTO;

namespace PlanPoker.Filters
{
  internal sealed class ExceptionFilter : IExceptionFilter
  {
    public void OnException(ExceptionContext context)
    {
      var dto = new ExceptionDto()
      {
        Message = context.Exception.Message
      };

      context.Result = new JsonResult(dto)
      {
        StatusCode = StatusCodes.Status500InternalServerError
      };

      context.ExceptionHandled = true;
    }
  }
}
