using EnglishTrainer.Infrastructure.SortOptions;
using EnglishTrainer.Services;
using EnglishTrainer.Services.Interfaces;
using EnglishTrainer.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTrainer.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordApiController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Index([FromServices] IApiWordService apiWordService)
        {
            var allWords = await apiWordService.GetAllAsync();

            return Ok(allWords);
        }

    }
}
