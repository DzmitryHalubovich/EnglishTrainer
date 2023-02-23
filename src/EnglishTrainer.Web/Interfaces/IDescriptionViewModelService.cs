using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.Web.Models;

namespace EnglishTrainer.Web.Interfaces
{
    public interface IDescriptionViewModelService 
    {
        Task<DescriptionViewModel> GetDescriptionViewModelByIdAsync(int id);
    }
}
