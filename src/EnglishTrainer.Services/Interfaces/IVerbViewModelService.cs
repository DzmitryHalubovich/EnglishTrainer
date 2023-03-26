using EnglishTrainer.ApplicationCore.Models;
using EnglishTrainer.Infrastructure.SortOptions;

namespace EnglishTrainer.Services
{
    public interface IVerbViewModelService
    {
        Task<IEnumerable<VerbViewModel>> GetAllVerbsAsync(SortFilterPageOptions options);
        Task<VerbViewModel> GetVerbViewModelByIdAsync(int id);
    }
}
