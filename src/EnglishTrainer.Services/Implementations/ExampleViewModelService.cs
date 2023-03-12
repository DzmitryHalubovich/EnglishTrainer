using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.ApplicationCore;
using EnglishTrainer.ApplicationCore.Models;

namespace EnglishTrainer.Services
{
    public class ExampleViewModelService : IExampleViewModelService
    {
        private readonly IRepository<Example> _exampleRepository;

        public ExampleViewModelService(IRepository<Example> exampleRepository)
        {
            _exampleRepository=exampleRepository;
        }

        public Task CreateExampleAsync(ExampleViewModel viewModel)
        {
            throw new NotImplementedException();

        }

        public Task UpdateExampleAsync(ExampleViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
