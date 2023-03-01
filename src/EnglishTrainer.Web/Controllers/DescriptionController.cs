using EnglishTrainer.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EnglishTrainer.Web.Controllers
{
    public class DescriptionController : Controller
    {
        private readonly IDescriptionViewModelService _descriptionViewModelService;
        private readonly ILogger<DescriptionController> _logger;

        public DescriptionController(
            IDescriptionViewModelService descriptionViewModelService, 
            ILogger<DescriptionController> logger)
        {
            _descriptionViewModelService = descriptionViewModelService;
            _logger=logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Details(int id) 
        {
            var foudDescription = await _descriptionViewModelService.GetDescriptionViewModelByIdAsync(id);
            return View(foudDescription);
        }
    }
}
