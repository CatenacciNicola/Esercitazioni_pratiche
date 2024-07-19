using System.Linq;
using ContravvenzioniWebApp.Data;
using ContravvenzioniWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContravvenzioniWebApp.Controllers
{
    public class ViolazioneController : Controller
    {
        private readonly ViolazioneDAO _violazioneDAO;

        public ViolazioneController(ViolazioneDAO violazioneDAO)
        {
            _violazioneDAO = violazioneDAO;
        }

        public IActionResult Index()
        {
            var violazioni = _violazioneDAO.GetAll();
            return View(violazioni);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Violazione violazione)
        {
            if (ModelState.IsValid)
            {
                _violazioneDAO.Add(violazione);
                return RedirectToAction("Index");
            }
            return View(violazione);
        }
    }
}
