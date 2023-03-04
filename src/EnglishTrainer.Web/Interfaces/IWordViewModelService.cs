using EnglishTrainer.Web.Models;
using EnglishTrainer.Web.Services.QueryOptions;

namespace EnglishTrainer.Web.Interfaces
{
    public interface IWordViewModelService
    {
        Task<IList<WordViewModel>> GetAllWordsAsync(VerbQueryOptions options);
        Task CreateNewWordAsync(WordViewModel wordViewModel);

        Task<WordViewModel> GetWordViewModelByIdAsync(int id);

    }
}
