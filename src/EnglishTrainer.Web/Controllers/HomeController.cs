using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EnglishTrainer.ApplicationCore.Models;

namespace EnglishTrainer.Web.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

}
