using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.Web.Interfaces;
using EnglishTrainer.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTrainer.Web.Controllers
{
    public class VerbController : Controller
    {
        private readonly IRepository<Verb> _verbRepository;
        private readonly IVerbViewModelService _verbViewModelService;

        public VerbController(IRepository<Verb> verbRepository, IVerbViewModelService verbViewModelService)
        {
            _verbRepository= verbRepository;
            _verbViewModelService= verbViewModelService;
        }

        public async Task <IActionResult> MainTable()
        {
            var verbViewModel = await _verbViewModelService.GetAllVerbs(); 

            return View(verbViewModel);
        }

        public IActionResult MainPage()  => View();

    }
}
