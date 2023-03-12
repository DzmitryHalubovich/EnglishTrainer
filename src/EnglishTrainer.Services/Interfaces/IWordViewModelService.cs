using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Models;
using EnglishTrainer.ApplicationCore.Response;

namespace EnglishTrainer.Services
{
    public interface IWordViewModelService
    {
        Task<IEnumerable<WordViewModel>> GetAllWordsAsync();
        Task<IBaseResponse<Word>> CreateNewWordAsync(WordViewModel wordViewModel);
        Task<WordViewModel> GetWordViewModelByIdAsync(int id);
        Task UpdateWordAsync(WordViewModel viewModel);

    }
}
