using AutoMapper;
using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.ApplicationCore.Models;
using EnglishTrainer.ApplicationCore.QueryOptions;
using EnglishTrainer.ApplicationCore.Response;
using EnglishTrainer.Services;
using Microsoft.Extensions.Logging;

namespace EnglishTrainer.ApplicationCore
{
    public class WordViewModelService : IWordViewModelService
    {
        private readonly IRepository<Word> _wordRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<WordViewModelService> _logger;

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

                //VerbQueryOptions options = new VerbQueryOptions();

                var word = _wordRepository.GetAll().Where(x => x.Name == wordViewModel.Name).FirstOrDefault();


                //TO DO Проверку на наличие слова в словаре

                //var task = _wordRepository.GetAllAsync(wordViewModel).Where;


                if (word is not null)
                {
                    return new BaseResponse<Word>()
                    {
                        Description = "Такое слово уже есть в словаре!",
                        StatusCode = Enums.StatusCode.WordIsHasAlready
                    };
                }

                //var newWord = _mapper.Map<Word>(wordViewModel);
                var newWord = new Word()
                {
                    Name= wordViewModel.Name,
                    Examples= wordViewModel.Examples,
                    PartsOfSpeech= wordViewModel.PartsOfSpeech,
                    TranslateVariants= wordViewModel.TranslateVariants,
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

        public async Task<IList<WordViewModel>> GetAllWordsAsync(VerbQueryOptions wordQueryOptions)
        {
            var options = new QueryEntityOptions<Word>()
                .SetCurentPageAndPageSize(wordQueryOptions.PageOptions);

            var allWords = await _wordRepository.GetAllAsync(options);

            var words = allWords.Select(item => new WordViewModel()
            {
                Id = item.Id,
                Name= item.Name,
                Examples= item.Examples,
                PartsOfSpeech= item.PartsOfSpeech,
                TranslateVariants = item.TranslateVariants
            }).ToList();

            return words;
        }

        public async Task<WordViewModel> GetWordViewModelByIdAsync(int id)
        {
            var entity = await _wordRepository.GetByIdAsync(id, x=>x.PartsOfSpeech,t=>t.Examples);

            var result = _mapper.Map<WordViewModel>(entity);

            return result;
        }
    }
}
