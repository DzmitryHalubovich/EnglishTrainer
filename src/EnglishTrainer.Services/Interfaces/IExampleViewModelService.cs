using EnglishTrainer.ApplicationCore.Models;

namespace EnglishTrainer.Services
{
    public interface IExampleViewModelService
    {
        Task<ExampleViewModel> GetExampleViewModelByIdAsync(int id);
        Task DeleteExampleAsync(int id);

        Task CreateExampleAsync(ExampleViewModel viewModel);

        Task UpdateExampleAsync(ExampleViewModel viewModel);


    }
}
