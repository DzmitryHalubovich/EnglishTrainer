using EnglishTrainer.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTrainer.Web.Controllers
{
    public class ExampleController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var newExample = new ExampleViewModel();

            return View(newExample);
        }
    }
}
