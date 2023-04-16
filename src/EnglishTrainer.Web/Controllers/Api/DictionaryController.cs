using EnglishTrainer.ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        [Route("dictionaryPartial")]
        public async Task<IActionResult> DictionaryPartial()
        {
            var dictionary = new List<WordViewModel>();

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
