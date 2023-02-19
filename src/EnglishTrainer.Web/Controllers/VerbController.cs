using AutoMapper;
using EnglishTrainer.ApplicationCore.Entities;
using EnglishTrainer.ApplicationCore.Interfaces;
using EnglishTrainer.Web.Interfaces;
using EnglishTrainer.Web.Models;
using EnglishTrainer.Web.Services.QueryOptions;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTrainer.Web.Controllers
{
    public class VerbController : Controller
    {
        private readonly IVerbViewModelService _verbViewModelService;
        private readonly IMapper _mapper;

        public VerbController(IVerbViewModelService verbViewModelService, IMapper mapper)
        {
            _verbViewModelService= verbViewModelService;
            _mapper = mapper;
        }

        public async Task <IActionResult> MainTable(VerbQueryOptions options)
        {
            var verbViewModel = await _verbViewModelService.GetAllVerbsAsync(options);
            options.PageOptions.CurrentElementsCount = verbViewModel.Count;

            VerbIndexViewModel verbList = new VerbIndexViewModel()
            {
                Options = options,
                VerbsList = verbViewModel
            };

            return View(verbList);
        }

        public IActionResult MainPage()  => View();

    }
}
