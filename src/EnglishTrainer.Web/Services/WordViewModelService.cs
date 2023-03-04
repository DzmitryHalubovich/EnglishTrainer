using AutoMapper;
using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.ApplicationCore.QueryOptions;
using EnglishTrainer.Web.Interfaces;
using EnglishTrainer.Web.Models;
using EnglishTrainer.Web.Services.QueryOptions;

namespace EnglishTrainer.Web.Services
{
    public class WordViewModelService : IWordViewModelService
    {
        private readonly IRepository<Word> _wordRepository;
        private readonly IMapper _mapper;

        public WordViewModelService(IRepository<Word> wordRepository, IMapper mapper)
        {
            _wordRepository=wordRepository;
            _mapper=mapper;
        }

        public async Task CreateNewWordAsync(WordViewModel wordViewModel)
        {
            var newWord = _mapper.Map<Word>(wordViewModel);
            await _wordRepository.CreateAsync(newWord);
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
            var entity = await _wordRepository.GetByIdAsync(id);

            var result = _mapper.Map<WordViewModel>(entity);

            return result;
        }
    }
}
