using EnglishTrainer.ApplicationCore.Models;

namespace EnglishTrainer.Services.Interfaces
{
    public interface IApiWordService
    {
        Task<List<WordViewModel>> GetAllAsync();

    }
}
