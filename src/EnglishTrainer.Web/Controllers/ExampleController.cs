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
        private readonly IWordViewModelService _wordViewModelService;

        public ExampleController(IExampleViewModelService exampleViewModelService, IWordViewModelService wordViewModelService)
        {
            _exampleViewModelService=exampleViewModelService;
            _wordViewModelService=wordViewModelService;
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            var newExample = new ExampleViewModel();
            newExample.WordId = id;


            return PartialView("_createPartial", newExample);
            //return View(newExample);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExampleViewModel model)
        {
           await _exampleViewModelService.CreateExampleAsync(model);

            var wordViewModel = await _wordViewModelService.GetWordViewModelByIdAsync(model.Id);

            return RedirectToAction("Details", "Word", wordViewModel);
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
