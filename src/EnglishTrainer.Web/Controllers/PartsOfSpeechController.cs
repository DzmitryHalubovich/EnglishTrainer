using EnglishTrainer.ApplicationCore.Models;
using EnglishTrainer.ApplicationCore;
using EnglishTrainer.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTrainer.Web.Controllers
{
    public class PartsOfSpeechController : Controller
    {
        private readonly IPartsOfSpeechViewModelService _partsOfSpeechViewModelService;

        public PartsOfSpeechController(IPartsOfSpeechViewModelService partsOfSpeechViewModelService)
        {
            _partsOfSpeechViewModelService=partsOfSpeechViewModelService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _partsOfSpeechViewModelService.GetPartViewModelByIdAsync(id);
            if (result == null)
            {
                return RedirectToAction("MainTable");
            }
           
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PartsOfSpeechViewModel wordViewModel)
        {
            await _partsOfSpeechViewModelService.UpdatePartsAsync(wordViewModel);
            return RedirectToAction("MainTable", "Word");
        }
    }
}

