using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTrainer.Web.Controllers
{
    public class VerbController : Controller
    {
        private readonly IRepository<Verb> _verbRepository;

        public VerbController(IRepository<Verb> verbRepository)
        {
            _verbRepository= verbRepository;
        }

        public IActionResult MainTable()
        {
            var verbViewModel = _verbRepository.GetAll().Select(item => new VerbViewModel()
            {
                Id= item.Id,
                Infinitive=item.Infinitive,
                PastParticiple=item.PastParticiple,
                PastSimple=item.PastSimple,
                TranslateRu = item.TranslateRu
            });

            return View(verbViewModel);
        }

        public IActionResult MainPage()  => View();

        public IActionResult Index()
        {
            var apartmentsViewModel = _verbRepository.GetAll().Select(item => new VerbViewModel()
            {
                Id = item.Id,
                Infinitive=item.Infinitive,
                PastParticiple=item.PastParticiple,
                PastSimple=item.PastSimple,
                TranslateRu = item.TranslateRu
            }).ToList();

            return View(apartmentsViewModel);
        }
    }
}
