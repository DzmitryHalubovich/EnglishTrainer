using EnglishTrainer.ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace EnglishTrainer.Web.Controllers.Api
{
    [Route("dictionary")]
    public class DictionaryController : Controller
    {

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
        public async Task<IActionResult> DictionaryPartial([FromServices] IHttpClientFactory _clientFactory)
        {
            var dictionary = new List<WordViewModel>();

            ///////////////////////////////////////

            var request = new HttpRequestMessage(HttpMethod.Get, "");

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);

            /////////////////////

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5268/api/dictionary"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    dictionary = JsonConvert.DeserializeObject<List<WordViewModel>>(apiResponse);
                }
            }

            return PartialView("_DictionaryPartial", dictionary);
        }
    }
}
