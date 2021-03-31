using System;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;

namespace PlanPoker.Domain.Services
{
  public class ExampleService
  {
    private readonly IRepository<ExampleEntity> exampleRepository;

    public ExampleService(IRepository<ExampleEntity> exampleRepository)
    {
      this.exampleRepository = exampleRepository;
    }

    public int TestMethod(int num)
    {
      return num;
    }

    public int ThrowException(int id)
    {
      throw new Exception($"Exception throwed {id}");
    }
  }
}
