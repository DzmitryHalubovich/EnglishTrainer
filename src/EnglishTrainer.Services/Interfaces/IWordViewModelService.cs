
using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Models;
using EnglishTrainer.ApplicationCore.QueryOptions;
using EnglishTrainer.ApplicationCore.Response;

namespace EnglishTrainer.Services
{
    public interface IWordViewModelService
    {
        Task<IList<WordViewModel>> GetAllWordsAsync(VerbQueryOptions options);
        Task<IBaseResponse<Word>> CreateNewWordAsync(WordViewModel wordViewModel);
        Task UpdateWordAsync(WordViewModel viewModel);
        Task<WordViewModel> GetWordViewModelByIdAsync(int id);
        List<WordShortViewModel> GetLastFiveWords();

        IQueryable<Word> GetAllWords();
    }
}
