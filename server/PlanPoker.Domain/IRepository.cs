using System;
using System.Linq;
using PlanPoker.Domain.Entities;

namespace PlanPoker.Domain.Repositories
{
  public interface IRepository<T> where T : IEntity
  {
    T Save(T entity);

    T Get(Guid id);

    IQueryable<T> GetAll();

    T Delete(Guid id);
  }
}
