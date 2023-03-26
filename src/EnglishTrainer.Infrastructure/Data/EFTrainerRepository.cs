using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.Infrastructure.QueryObject;
using EnglishTrainer.Infrastructure.SortOptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace EnglishTrainer.Infrastructure.Data
{
    public class EFTrainerRepository<T> : IRepository<T> where T : BaseModel
    {
        private readonly EnglishTrainerContext _dbContext;

        public EFTrainerRepository(EnglishTrainerContext dbContext)
        {
              _dbContext= dbContext;
        }

        public async Task CreateAsync(T entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> TotalCount()
        {
            return await _dbContext.Set<T>().CountAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(
            SortFilterPageOptions options,
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool isTracking = false)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (!isTracking) { query = query.AsNoTracking(); }
            if (predicate is not null) { query = query.Where(predicate); }
            if (include is not null) { query = include(query); }

            //query.Page(options.PageNum - 1, options.PageSize);

            return orderBy is not null
              ? await orderBy(query.Page(options.PageNum - 1, options.PageSize)).ToListAsync()
              :  await query.Page(options.PageNum - 1, options.PageSize).ToListAsync();
        }

        public async Task<T?> GetFirstOrDefaultAsync(
            Expression<Func<T,bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T,object>>? include = null,
            bool isTracking = false)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (!isTracking) { query = query.AsNoTracking(); }
            if (predicate is not null) { query = query.Where(predicate); }
            if (include is not null) { query = include(query); }

            return orderBy is not null 
                ? await orderBy(query).FirstOrDefaultAsync()
                :  await query.FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync(); 
        }
    }
}
