using EnglishTrainer.ApplicationCore;
using EnglishTrainer.ApplicationCore.Models;
using EnglishTrainer.Services;
using EnglishTrainer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTrainer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DictionaryController : ControllerBase
    {
        private readonly IWordViewModelService _wordViewModelService;

        public DictionaryController(IWordViewModelService wordViewModelService)
        {
            _wordViewModelService=wordViewModelService;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromServices] IApiWordService apiWordService)
        {
            var allWords = await apiWordService.GetAllAsync();

            return Ok(allWords);
        }

        [HttpPost]
        public async Task<IActionResult> AddWord(WordViewModel wordViewModel)
        {

            var response = await _wordViewModelService.CreateNewWordAsync(wordViewModel);

            //await wordViewModelService.CreateNewWordAsync(wordViewModel);
            return Ok();
        }
    }
}
