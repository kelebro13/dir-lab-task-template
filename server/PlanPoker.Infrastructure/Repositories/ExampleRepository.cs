using System;
using System.Linq;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;

namespace PlanPoker.Infrastructure.Repositories
{
  public class ExampleRepository : IRepository<ExampleEntity>
  {
    public ExampleEntity Delete(Guid id)
    {
      throw new NotImplementedException();
    }

    public ExampleEntity Get(Guid id)
    {
      throw new NotImplementedException();
    }

    public IQueryable<ExampleEntity> GetAll()
    {
      throw new NotImplementedException();
    }

    public ExampleEntity Save(ExampleEntity entity)
    {
      throw new NotImplementedException();
    }
  }
}
