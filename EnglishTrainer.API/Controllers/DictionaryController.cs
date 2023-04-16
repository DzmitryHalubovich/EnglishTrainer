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
        [HttpGet]
        public async Task<IActionResult> Index([FromServices] IApiWordService apiWordService)
        {
            var allWords = await apiWordService.GetAllAsync();

            return Ok(allWords);
        }

        [HttpPost]
        public async Task<IActionResult> AddWord([FromServices] IWordViewModelService wordViewModelService, WordViewModel viewModel)
        {
            await wordViewModelService.CreateNewWordAsync(viewModel);
            return Ok();
        }
    }
}
