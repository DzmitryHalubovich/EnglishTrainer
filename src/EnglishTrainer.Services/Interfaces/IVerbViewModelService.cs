using EnglishTrainer.ApplicationCore.Models;
using EnglishTrainer.ApplicationCore.QueryOptions;

namespace EnglishTrainer.Services
{
    public interface IVerbViewModelService
    {
        Task<IList<VerbViewModel>> GetAllVerbsAsync(VerbQueryOptions options);
        Task<VerbViewModel> GetVerbViewModelByIdAsync(int id);
    }
}
