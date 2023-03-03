using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.Web.Interfaces;
using EnglishTrainer.Web.Models;

namespace EnglishTrainer.Web.Services
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
    }
}
