using System;
using PlanPoker.Domain.Entities;

namespace PlanPoker.Models
{
  public sealed class Login : IEntity
  {
    /// <inheritdoc/>
    Guid IEntity.Id => this.User;

    public Guid User { get; init; }

    public string UserName { get; init; }

    public string Password { get; init; }
  }
}
