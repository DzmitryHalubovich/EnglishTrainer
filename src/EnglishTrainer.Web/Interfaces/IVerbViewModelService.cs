using EnglishTrainer.Web.Models;
using EnglishTrainer.Web.Services.QueryOptions;

namespace EnglishTrainer.Web.Interfaces
{
    public interface IVerbViewModelService
    {
        Task<IList<VerbViewModel>> GetAllVerbsAsync(VerbQueryOptions options);
    }
}
