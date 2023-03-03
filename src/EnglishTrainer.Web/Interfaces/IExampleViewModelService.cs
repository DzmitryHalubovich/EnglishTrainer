using EnglishTrainer.Web.Models;

namespace EnglishTrainer.Web.Interfaces
{
    public interface IExampleViewModelService
    {
        Task CreateExampleAsync(ExampleViewModel viewModel);
    }
}
