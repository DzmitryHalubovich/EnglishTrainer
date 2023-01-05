using EnglishTrainer.ApplicationCore.Entities;

namespace EnglishTrainer.ApplicationCore.Interfaces
{
    public interface IRepository <T> where T : class
    {
        IEnumerable<Verb> GetAll();
    }
}
