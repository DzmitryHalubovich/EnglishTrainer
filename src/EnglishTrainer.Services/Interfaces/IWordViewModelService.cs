
using EnglishTrainer.ApplicationCore.Models;
using EnglishTrainer.ApplicationCore.QueryOptions;

namespace EnglishTrainer.Services
{
    public interface IWordViewModelService
    {
        Task<IList<WordViewModel>> GetAllWordsAsync(VerbQueryOptions options);
        Task CreateNewWordAsync(WordViewModel wordViewModel);

        Task<WordViewModel> GetWordViewModelByIdAsync(int id);

    }
}
