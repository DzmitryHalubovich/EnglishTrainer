﻿using EnglishTrainer.ApplicationCore.Models;
using EnglishTrainer.ApplicationCore.QueryOptions;

using Microsoft.AspNetCore.Mvc;


namespace EnglishTrainer.Services
{
    public class WordController : Controller
    {
        private readonly IWordViewModelService _wordViewModelService;

        public WordController(IWordViewModelService wordViewModelService)
        {
            _wordViewModelService=wordViewModelService;
        }

        public async Task<IActionResult> MainTable(VerbQueryOptions options)
        {
            var wordViewModel = await _wordViewModelService.GetAllWordsAsync(options);
            options.PageOptions.CurrentElementsCount = wordViewModel.Count;

            WordIndexViewModel verbList = new WordIndexViewModel()
            {
                Options = options,
                WordsList = wordViewModel
            };

            return View(verbList);
        }


        public IActionResult LastFiveWords()
        {
            var lastFiveWords = _wordViewModelService.GetLastFiveWords();

            return PartialView(lastFiveWords);
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
                return Ok(new { description = response.Description});
            }

            return BadRequest(new { description = response.Description });
        }

        public async Task<IActionResult> Details(int id)
        {
            var existingWord = await  _wordViewModelService.GetWordViewModelByIdAsync(id);

            return View(existingWord);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var existingWord =  await _wordViewModelService.GetWordViewModelByIdAsync(id);

            //if (existingWord is null)
            //{
            //    return BadRequest(new { description = "Что-то пошло не так..."});
            //}

            return View(existingWord);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(WordViewModel wordViewModel)
        {
            await _wordViewModelService.UpdateWordAsync(wordViewModel);
            return RedirectToAction("MainTable");
        }
    }
}
