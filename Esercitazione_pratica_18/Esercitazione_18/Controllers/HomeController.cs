using Esercitazione_18.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Esercitazione_18.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Inizializzo il logger tramite dependency injection
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Restituisco la vista per la homepage
        public IActionResult Index()
        {
            return View();
        }

        // Restituisco la vista per la pagina della privacy
        public IActionResult Privacy()
        {
            return View();
        }

        // Gestisco gli errori e restituisco la vista di errore
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Passo il RequestId corrente alla vista di errore
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
