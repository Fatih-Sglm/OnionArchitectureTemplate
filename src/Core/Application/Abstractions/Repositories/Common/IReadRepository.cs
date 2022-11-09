using Application.Commons.DynamicQuery;
using Application.Commons.Pagination;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Abstractions.Repositories.Common
{

    public interface IReadRepository<T> : IRepository<T> where T : class, IEntity
    {


        Task<T?> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>,
                                         IIncludableQueryable<T, object>>? include = null, bool enableTracking = true,
                                         CancellationToken cancellationToken = default);

        Task<IQueryable<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                        bool enableTracking = true,
                                        CancellationToken cancellationToken = default);

        Task<IQueryable<T>> GetListDynamicAsync(Dynamic dynamic, Func<IQueryable<T>,
                                                  IIncludableQueryable<T, object>>? include = null,
                                                  bool enableTracking = true,
                                                  CancellationToken cancellationToken = default);



        Task<IPaginate<T>> GetListAsyncWithPaginate(Expression<Func<T, bool>>? predicate = null,
                                                    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                                    Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                                    int index = 0, int size = 10, bool enableTracking = true,
                                                    CancellationToken cancellationToken = default);


        Task<IPaginate<T>> GetListDynamicAsyncWithPaginate(Dynamic dynamic,
                                                             Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                                             int index = 0, int size = 10, bool enableTracking = true,
                                                             CancellationToken cancellationToken = default);
    }
}
