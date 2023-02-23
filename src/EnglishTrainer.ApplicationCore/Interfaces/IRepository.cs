using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.QueryOptions;
using System.Linq.Expressions;

namespace EnglishTrainer.ApplicationCore.Interfaces
{
    public interface IRepository <T> where T : class
    {
        IEnumerable<T> GetAll();

        Task<List<T>> GetAllAsync(QueryEntityOptions<T> options);

        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);
    }
}
