using EnglishTrainer.ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;

namespace EnglishTrainer.Web.Controllers
{
    [Route("dictionary")]
    public class DictionaryController : Controller
    {

        private readonly IHttpClientFactory _clientFactory;

        public DictionaryController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("addWordPartial")]
        public IActionResult Create()
        {
            var newWord = new WordViewModel();

            return PartialView("_AddWordPartial", newWord);
        }

        [HttpGet]
        [Route("dictionaryPartial")]
        public async Task<IActionResult> DictionaryPartial()
        {
            var client = _clientFactory.CreateClient("Dictionary");
            string errorString;

            try
            {
                var dictionary = await client.GetFromJsonAsync<List<WordViewModel>>("dictionary");
                errorString = null;
                return PartialView("_DictionaryPartial", dictionary);
            }
            catch (Exception ex)
            {
                errorString = $"There was an error getting our forecast: {ex.Message}";
            }

            return View();
        }


        [HttpPost]
        [Route("addWordPartial")]
        public async Task<IActionResult> Create(WordViewModel wordViewModel)
        {
            var client = _clientFactory.CreateClient("Dictionary");
            string errorString;

            try
            {
                var dictionary = await client.PostAsJsonAsync("dictionary", wordViewModel);
                errorString = null;
            }
            catch (Exception ex)
            {
                errorString = $"There was an error getting our forecast: {ex.Message}";
            }

            return RedirectToAction("Index");
        }
    }
}
