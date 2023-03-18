using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.ApplicationCore;
using EnglishTrainer.ApplicationCore.Models;
using AutoMapper;

namespace EnglishTrainer.Services
{
    public class ExampleViewModelService : IExampleViewModelService
    {
        private readonly IRepository<Example> _exampleRepository;
        private readonly IMapper _mapper;

        public ExampleViewModelService(IRepository<Example> exampleRepository, IMapper mapper)
        {
            _exampleRepository=exampleRepository;
            _mapper=mapper;
        }

        public async Task CreateExampleAsync(ExampleViewModel viewModel)
        {
            //var newExample = _mapper.Map<Example>(viewModel);

            //TODO добавить нормальный профиль в мапере

            var newExample = new Example()
            {
                EnglishExample = viewModel.EnglishExample,
                RussianExample= viewModel.RussianExample,
                WordId= viewModel.Id,
            };


            await _exampleRepository.CreateAsync(newExample);
            
        }

        public async Task<ExampleViewModel> GetExampleViewModelByIdAsync(int id)
        {
            var existedExample = await _exampleRepository.GetFirstOrDefaultAsync(predicate:x=>x.Id==id);

            return _mapper.Map<ExampleViewModel>(existedExample);
        }

        public async Task UpdateExampleAsync(ExampleViewModel viewModel)
        {
            var existingWord = await _exampleRepository.GetFirstOrDefaultAsync(predicate: x => x.Id==viewModel.Id);

            existingWord.EnglishExample = viewModel.EnglishExample;
            existingWord.RussianExample = viewModel.RussianExample;

            await _exampleRepository.UpdateAsync(existingWord);
        }
    }
}
