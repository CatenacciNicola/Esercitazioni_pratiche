using System.Linq;
using ContravvenzioniWebApp.Data;
using ContravvenzioniWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContravvenzioniWebApp.Controllers
{
    public class AnagraficaController : Controller
    {
        private readonly AnagraficaDAO _anagraficaDAO;

        public AnagraficaController(AnagraficaDAO anagraficaDAO)
        {
            _anagraficaDAO = anagraficaDAO;
        }

        public IActionResult Index()
        {
            var anagrafiche = _anagraficaDAO.GetAll();
            return View(anagrafiche);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Anagrafica anagrafica)
        {
            if (ModelState.IsValid)
            {
                _anagraficaDAO.Add(anagrafica);
                return RedirectToAction("Index");
            }
            return View(anagrafica);
        }
    }
}
