using EnglishTrainer.Web.Models;

namespace EnglishTrainer.Web.Interfaces
{
    public interface IVerbViewModelService
    {
        Task<IList<VerbViewModel>> GetAllVerbsAsync(int page, int pageSize);
    }
}
