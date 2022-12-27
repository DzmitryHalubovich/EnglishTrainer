using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTrainer.Web.Controllers
{
    public sealed class VerbController : Controller
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
    }
}
