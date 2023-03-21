using EnglishTrainer.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTrainer.Web.Controllers
{
    public class TestsController : Controller
    {
        private readonly IVerbViewModelService _verbViewModelService;

        public TestsController(IVerbViewModelService verbViewModelService)
        {
            _verbViewModelService=verbViewModelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> GetNewVerb()
        {

            var generateRandomVerbId = new Random();

            int randomId = generateRandomVerbId.Next(1, 100);

            var randomVerb = await _verbViewModelService.GetVerbViewModelByIdAsync(randomId);

            return PartialView(randomVerb);
        }

    }
}
