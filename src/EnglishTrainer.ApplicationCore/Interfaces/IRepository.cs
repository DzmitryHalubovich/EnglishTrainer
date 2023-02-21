using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.QueryOptions;

namespace EnglishTrainer.ApplicationCore.Interfaces
{
    public interface IRepository <T> where T : class
    {
        IEnumerable<Verb> GetAll();

        Task<List<T>> GetAllAsync(QueryEntityOptions<T> options);

        Task<T> GetByIdAsync(int id);
    }
}
