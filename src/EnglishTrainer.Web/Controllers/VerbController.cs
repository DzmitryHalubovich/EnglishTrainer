using AutoMapper;
using EnglishTrainer.ApplicationCore.Models;
using EnglishTrainer.ApplicationCore.QueryOptions;
using EnglishTrainer.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTrainer.Web.Controllers
{
    public class VerbController : Controller
    {
        private readonly IVerbViewModelService _verbViewModelService;
        private readonly IMapper _mapper;
        private readonly ILogger<VerbController> _logger;

        public VerbController(IVerbViewModelService verbViewModelService, IMapper mapper, ILogger<VerbController> logger)
        {
            _verbViewModelService= verbViewModelService;
            _mapper = mapper;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("On main page.");
            return View();
        }

        public async Task <IActionResult> MainTable(VerbQueryOptions options)
        {
            _logger.LogInformation("Processing of the request MainTable.");

            var verbViewModel = await _verbViewModelService.GetAllVerbsAsync(options);
            options.PageOptions.CurrentElementsCount = verbViewModel.Count;

            VerbIndexViewModel verbList = new VerbIndexViewModel()
            {
                Options = options,
                VerbsList = verbViewModel
            };

            _logger.LogInformation($"Return collection {verbList.VerbsList.ToString()} with {verbList.VerbsList.Count()} elements");

            return View(verbList);
        }

        public async Task<IActionResult> Details(int id)
        {
            var verbById = await _verbViewModelService.GetVerbViewModelByIdAsync(id);

            _logger.LogInformation("Processing of the request Details.");

            return View(verbById);
        }

        public IActionResult MainPage()  => View();

    }
}
