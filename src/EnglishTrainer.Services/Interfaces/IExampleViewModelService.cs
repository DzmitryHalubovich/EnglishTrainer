using EnglishTrainer.ApplicationCore.Models;

namespace EnglishTrainer.Services
{
    public interface IExampleViewModelService
    {
        Task CreateExampleAsync(ExampleViewModel viewModel);

        Task UpdateExampleAsync(ExampleViewModel viewModel);
    }
}
