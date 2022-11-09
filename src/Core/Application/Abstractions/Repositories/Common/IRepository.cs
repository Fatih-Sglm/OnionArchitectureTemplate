using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.Abstractions.Repositories.Common
{
    public interface IRepository<T> where T : class, IEntity
    {
        DbSet<T> Table { get; }
    }
}
