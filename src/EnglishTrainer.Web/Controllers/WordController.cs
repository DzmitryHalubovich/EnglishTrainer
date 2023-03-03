using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.Web.Interfaces;
using EnglishTrainer.Web.Models;
using EnglishTrainer.Web.Services.QueryOptions;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTrainer.Web.Controllers
{
    public class WordController : Controller
    {
        private readonly IWordViewModelService _wordViewModelService;

        public WordController(IWordViewModelService wordViewModelService)
        {
            _wordViewModelService=wordViewModelService;
        }

        public async Task<IActionResult> MainTable(VerbQueryOptions options)
        {
            var wordViewModel = await _wordViewModelService.GetAllWordsAsync(options);
            options.PageOptions.CurrentElementsCount = wordViewModel.Count;

            WordIndexViewModel verbList = new WordIndexViewModel()
            {
                Options = options,
                WordsList = wordViewModel
            };

            return View(verbList);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var newWord = new WordViewModel();

            return View(newWord);
        }
    }
}
