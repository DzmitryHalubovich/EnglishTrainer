using EnglishTrainer.ApplicationCore;
using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.ApplicationCore.Models;
using EnglishTrainer.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTrainer.Web.Controllers
{
    public class ExampleController : Controller
    {
        private readonly IExampleViewModelService _exampleViewModelService;

        public ExampleController(IRepository<Example> repository, IExampleViewModelService exampleViewModelService)
        {
            _exampleViewModelService=exampleViewModelService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var newExample = new ExampleViewModel();

            return View(newExample);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var existingWord = await _exampleViewModelService.GetExampleViewModelByIdAsync(id);

            return View(existingWord);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ExampleViewModel model)
        {
            await _exampleViewModelService.UpdateExampleAsync(model);

            return RedirectToAction("MainTable", "Word");
        }
    }
}
