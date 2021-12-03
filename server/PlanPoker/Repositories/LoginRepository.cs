using System;
using System.Collections.Generic;
using System.Linq;
using PlanPoker.Domain.Repositories;
using PlanPoker.Models;

namespace PlanPoker.Repositories
{
  internal sealed class LoginRepository : IRepository<Login>
  {
    private ICollection<Login> logins = new List<Login>();

    public Login Delete(Guid id)
    {
      var login = this.logins.FirstOrDefault(l => l.User == id);
      if (login is not null)
        this.logins.Remove(login);
      return login;
    }

    public Login Get(Guid id)
    {
      return this.logins.FirstOrDefault(l => l.User == id);
    }

    public IQueryable<Login> GetAll()
    {
      return this.logins.AsQueryable();
    }

    public Login Save(Login entity)
    {
      this.Delete(entity.User);
      this.logins.Add(entity);
      return entity;
    }
  }
}
