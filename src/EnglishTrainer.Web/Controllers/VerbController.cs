using EnglishTrainer.ApplicationCore;
using EnglishTrainer.Infrastructure.SortOptions;
using EnglishTrainer.Services;
using EnglishTrainer.Services.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTrainer.Web.Controllers
{
    public class VerbController : Controller
    {
        private readonly IVerbViewModelService _verbViewModelService;
        private readonly ILogger<VerbController> _logger;

        public VerbController(IVerbViewModelService verbViewModelService,ILogger<VerbController> logger)
        {
            _verbViewModelService= verbViewModelService;
            _logger = logger;
        }

        //[Authorize(AuthenticationSchemes = "Bearer ", Roles = "user")]
        public async Task <IActionResult> Index(SortFilterPageOptions options)
        {
            _logger.LogInformation("Processing of the request MainTable.");

            options.ElementsCount = await _verbViewModelService.TotalVerbsCount();

            ViewBag.PagesCount = (int)Math.Ceiling((double)options.ElementsCount  / options.PageSize);

            var verbViewModel = await _verbViewModelService.GetAllVerbsAsync(options);
          
            _logger.LogInformation($"Return collection {verbViewModel.ToString()} with {verbViewModel.Count()} elements");

            //return View(verbViewModel);
            return View(new IndexVerbViewModel(options, verbViewModel));
        }

        public async Task<IActionResult> Details(int id)
        {
            var verbById = await _verbViewModelService.GetVerbViewModelByIdAsync(id);

            _logger.LogInformation("Processing of the request Details.");

            return View(verbById);
        }


    }
}
