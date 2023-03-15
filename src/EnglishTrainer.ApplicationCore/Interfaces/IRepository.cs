using EnglishTrainer.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace EnglishTrainer.ApplicationCore.Interfaces
{
    public interface IRepository <T> where T : class
    {
        //IQueryable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool isTracking = false);

        Task CreateAsync(T entity);

        Task<T> GetFirstOrDefaultAsync(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool isTracking = false);

        Task DeleteAsync(T entity);

        Task UpdateAsync(T entity);
    }
}
