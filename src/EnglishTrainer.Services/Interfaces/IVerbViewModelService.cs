using EnglishTrainer.ApplicationCore.Models;


namespace EnglishTrainer.Services
{
    public interface IVerbViewModelService
    {
        Task<IEnumerable<VerbViewModel>> GetAllVerbsAsync();
        Task<VerbViewModel> GetVerbViewModelByIdAsync(int id);
    }
}
