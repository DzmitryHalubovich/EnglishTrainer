using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Enums;
using EnglishTrainer.ApplicationCore.Models;
using EnglishTrainer.Infrastructure.Data;
using EnglishTrainer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EnglishTrainer.Services
{
    public class WordController : Controller
    {
        private readonly IWordViewModelService _wordViewModelService;

        public WordController(IWordViewModelService wordViewModelService)
        {
            _wordViewModelService=wordViewModelService;
        }

        public async Task<IActionResult> Index()
        {
            var wordViewModel = await _wordViewModelService.GetAllWordsAsync();

            return View(wordViewModel);
        }

        //Создание обьекта и вью работает по примеру отсюда
        //https://metanit.com/sharp/mvc5/5.11.php

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var newWord = new WordViewModel();

            return View(newWord);
        }

        [HttpPost]
        public async Task<IActionResult> Create(WordViewModel wordViewModel)
        {
            var response = await _wordViewModelService.CreateNewWordAsync(wordViewModel);

            if (response.StatusCode == ApplicationCore.Enums.StatusCode.OK)
            {
                return Ok(new { description = response.Description });
            }

            return BadRequest(new { description = response.Description });
        }

        public async Task<IActionResult> Details(int id)
        {
            var existingWord = await _wordViewModelService.GetWordViewModelByIdAsync(id);

            return View(existingWord);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var existingWord = await _wordViewModelService.GetWordViewModelByIdAsync(id);

            return View(existingWord);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(WordViewModel wordViewModel)
        {
            await _wordViewModelService.UpdateWordAsync(wordViewModel);
            return RedirectToAction("MainTable");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _wordViewModelService.DeleteWordAsync(id);
            return RedirectToAction("Index");
        }
    }
}
