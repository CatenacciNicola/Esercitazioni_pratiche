using Esercitazione_17.Data;
using Esercitazione_17.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Esercitazione_17.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ClienteDao _clienteDao;

        public HomeController(ILogger<HomeController> logger, ClienteDao clienteDao)
        {
            _logger = logger;
            _clienteDao = clienteDao;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Clienti()
        {
            var clienti = _clienteDao.GetAllClienti();
            return View(clienti);
        }

        [HttpPost]
        public IActionResult AddCliente(Cliente cliente)
        {
            _clienteDao.AddCliente(cliente);
            return RedirectToAction("Clienti");
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
