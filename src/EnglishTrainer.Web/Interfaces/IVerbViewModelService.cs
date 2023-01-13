using EnglishTrainer.Web.Models;

namespace EnglishTrainer.Web.Interfaces
{
    public interface IVerbViewModelService
    {
        Task<IEnumerable<VerbViewModel>> GetAllVerbs();
    }
}
