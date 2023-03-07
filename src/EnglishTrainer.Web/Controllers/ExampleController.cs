using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTrainer.Web.Controllers
{
    public class ExampleController : Controller
    {
        private readonly IRepository<Example> _exampleRepository;

        public ExampleController(IRepository<Example> repository)
        {

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var newExample = new ExampleViewModel();

            return View(newExample);
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }
    }
}
