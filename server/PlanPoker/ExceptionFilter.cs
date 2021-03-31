using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PlanPoker
{
  internal class ExceptionFilter : IExceptionFilter
  {
    public void OnException(ExceptionContext context)
    {
      context.Result = new ContentResult
      {
        StatusCode = 500,
        Content = context.Exception.Message
      };
      context.ExceptionHandled = true;
    }
  }
}