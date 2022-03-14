using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using Ficha10;
using Ficha10.Controllers;
using Ficha10_view.Models;
using FREQ_2019419;

namespace Ficha10_view.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            CharactersController ncc = new CharactersController();
            //var characters = JsonLoader.DeserializeCharacters();
            return View(/*characters*/new Characters(ncc.Get().ToList()));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}