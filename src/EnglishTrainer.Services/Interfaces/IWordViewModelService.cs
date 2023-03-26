using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Models;
using EnglishTrainer.ApplicationCore.Response;
using EnglishTrainer.Infrastructure.SortOptions;

namespace EnglishTrainer.Services
{
    public interface IWordViewModelService
    {
        Task<IEnumerable<WordViewModel>> GetAllWordsAsync(SortFilterPageOptions options);
        Task<IBaseResponse<Word>> CreateNewWordAsync(WordViewModel wordViewModel);
        Task<WordViewModel> GetWordViewModelByIdAsync(int id);
        Task UpdateWordAsync(WordViewModel viewModel);
        Task<int> TotalWordCount();
        Task DeleteWordAsync(int id);

    }
}
