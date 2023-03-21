using AutoMapper;
using EnglishTrainer.ApplicationCore.Models;
using EnglishTrainer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

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

        public IActionResult Index()
        {
            _logger.LogInformation("On main page.");
            return View();
        }

        [Authorize(AuthenticationSchemes = "Bearer ", Roles = "Admin")]
        public async Task <IActionResult> MainTable()
        {
            _logger.LogInformation("Processing of the request MainTable.");

            var verbViewModel = await _verbViewModelService.GetAllVerbsAsync();
          
            _logger.LogInformation($"Return collection {verbViewModel.ToString()} with {verbViewModel.Count()} elements");

            return View(verbViewModel);
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
