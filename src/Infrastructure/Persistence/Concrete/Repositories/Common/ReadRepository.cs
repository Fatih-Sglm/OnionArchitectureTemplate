using Application.Abstractions.Repositories.Common;
using Application.Commons.DynamicQuery;
using Application.Commons.Pagination;
using Application.Extensions;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Persistence.Contexts;
using System.Linq.Expressions;

namespace Persistence.Concrete.Repositories.Common
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, IEntity, new()
    {
        private readonly ApplicationDbContext _context;

        public ReadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();




        #region GetAsync
        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>,
                                         IIncludableQueryable<T, object>>? include = null, bool enableTracking = true,
                                         CancellationToken cancellationToken = default)
        {
            IQueryable<T> queryable = Table.AsQueryable();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
        }
        #endregion
        #region GetList
        public async Task<IQueryable<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<T> queryable = Table.AsQueryable();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null)
                return await Task.FromResult(orderBy(queryable));
            return await Task.FromResult(queryable);
        }


        public async Task<IPaginate<T>> GetListAsyncWithPaginate(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            var queryable = await GetListAsync(predicate, orderBy, include, enableTracking, cancellationToken);
            return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
        }



        #endregion
        #region GetListDynamic

        public async Task<IQueryable<T>> GetListDynamicAsync(Dynamic dynamic, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<T> queryable = Table.AsQueryable().ToDynamic(dynamic);
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            return await Task.FromResult(queryable);
        }




        public async Task<IPaginate<T>> GetListDynamicAsyncWithPaginate(Dynamic dynamic, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            var queryable = await GetListDynamicAsync(dynamic, include, enableTracking, cancellationToken);
            return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
        }
        #endregion



    }
}
