using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Interfaces;
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

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        public async Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool isTracking = false)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (!isTracking) { query = query.AsNoTracking(); }
            if (predicate is not null) { query = query.Where(predicate); }
            if (include is not null) { query = include(query); }


            return orderBy is not null
              ? await orderBy(query).ToListAsync()
              :  await query.ToListAsync();
        }

        //public IQueryable<T> GetAllAsync()
        //{
        //    var allEntities = _dbContext.Set<T>().AsNoTracking();
        //    return allEntities;
        //}

        //public async Task<T?> GetByIdAsync(int id)
        //{
        //    var entity = await _dbContext.Set<T>().FindAsync(id);
        //    return entity;
        //}

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

            //var entity = await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            //if (include is not null)
            //{
            //    entity = include(entity);
            //}


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
