using Microsoft.AspNetCore.Mvc;
using PlanPoker.Services;

namespace PlanPoker.Controllers
{
  [ApiController]
  [Route("api/[controller]/[action]")]
  public class ExampleController : ControllerBase
  {
    private readonly ExampleService exampleService;

    public ExampleController(ExampleService exampleService)
    {
      this.exampleService = exampleService;
    }

    [HttpGet]
    public int Test(int id)
    {
      return this.exampleService.TestMethod(id);
    }
  }
}
