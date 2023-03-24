using AutoMapper;
using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.ApplicationCore.Models;
using EnglishTrainer.ApplicationCore.Response;
using EnglishTrainer.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EnglishTrainer.ApplicationCore
{
    public class WordViewModelService : IWordViewModelService
    {
        private readonly IRepository<Word> _wordRepository;
        private readonly ILogger<WordViewModelService> _logger;
        private readonly IMapper _mapper;

        public WordViewModelService(IRepository<Word> wordRepository, IMapper mapper, ILogger<WordViewModelService> logger)
        {
            _wordRepository=wordRepository;
            _mapper=mapper;
            _logger=logger;
        }

        public async Task<IBaseResponse<Word>> CreateNewWordAsync(WordViewModel wordViewModel)
        {
            try
            {
                _logger.LogInformation($"Запрос на добавление нового слова в словарь - {wordViewModel.Name}");

                var word = await  _wordRepository.GetFirstOrDefaultAsync(predicate:x=>x.Name == wordViewModel.Name);

                if (word is not null)
                {
                    return new BaseResponse<Word>()
                    {
                        Description = "Такое слово уже есть в словаре!",
                        StatusCode = Enums.StatusCode.WordIsHasAlready
                    };
                }

            //    return orderBy is not null
            //? await orderBy(query).ToListAsync()
            //: await query.ToListAsync();

                var newWord = new Word()
                {
                    Name = wordViewModel.Name,
                    Examples = wordViewModel.Examples.FirstOrDefault().EnglishExample is not null 
                    ? wordViewModel.Examples 
                    : null,
                    TranslateVariants = wordViewModel.TranslateVariants,
                    Description = wordViewModel.Description,
                    Created = DateTime.Now
                };

                await _wordRepository.CreateAsync(newWord);

                _logger.LogInformation($"Слово {newWord.Name} успешно добавлено в словарь");

                return new BaseResponse<Word>
                {
                    StatusCode = Enums.StatusCode.OK,
                    Description = "Слово добавлено в словарь!",
                };

            }
            catch (Exception ex)
            {
                _logger.LogError(ex,$"[WordViewModelService.Create]: {ex.Message}");
                
                return new BaseResponse<Word>()
                {
                    StatusCode = Enums.StatusCode.InternalServerError,
                };
            }
        }

        public async Task DeleteWordAsync(int id)
        {
            var existingWord = await _wordRepository.GetFirstOrDefaultAsync(predicate: x=>x.Id == id);
            await _wordRepository.DeleteAsync(existingWord);

        }

        public async Task<IEnumerable<WordViewModel>> GetAllWordsAsync()
        {
            _logger.LogInformation("Получение списка слов из словаря.");

            var getAllWords = await _wordRepository.GetAllAsync(isTracking:true);

            var allWordsDto = _mapper.Map<IEnumerable<WordViewModel>>(getAllWords);

            return allWordsDto;
        }
        
        public async Task<WordViewModel> GetWordViewModelByIdAsync(int id)
        {
            var entity = await _wordRepository.GetFirstOrDefaultAsync(
                predicate: x=>x.Id==id,
                include:query => query.Include(t=>t.Examples), 
                isTracking:false);

            var result = _mapper.Map<WordViewModel>(entity);

            return result;
        }

        public async Task UpdateWordAsync(WordViewModel viewModel)
        {
            var existingWord = await _wordRepository.GetFirstOrDefaultAsync(predicate: x=>x.Id==viewModel.Id);

            existingWord.Created = DateTime.Now;
            existingWord.Examples = viewModel.Examples;
            existingWord.TranslateVariants = viewModel.TranslateVariants;
            existingWord.Name = viewModel.Name;
            existingWord.Description = viewModel.Description;

           await  _wordRepository.UpdateAsync(existingWord);
        }


    }
}
