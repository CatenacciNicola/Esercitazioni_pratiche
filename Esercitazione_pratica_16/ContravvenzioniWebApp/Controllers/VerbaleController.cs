using System.Collections.Generic;
using System.Linq;
using ContravvenzioniWebApp.Data;
using ContravvenzioniWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContravvenzioniWebApp.Controllers
{
    public class VerbaleController : Controller
    {
        private readonly VerbaleDAO _verbaleDAO;
        private readonly ViolazioniAVerbaleDAO _violazioniAVerbaleDAO;
        private readonly AnagraficaDAO _anagraficaDAO;
        private readonly ViolazioneDAO _violazioneDAO;

        public VerbaleController(VerbaleDAO verbaleDAO, ViolazioniAVerbaleDAO violazioniAVerbaleDAO, AnagraficaDAO anagraficaDAO, ViolazioneDAO violazioneDAO)
        {
            _verbaleDAO = verbaleDAO;
            _violazioniAVerbaleDAO = violazioniAVerbaleDAO;
            _anagraficaDAO = anagraficaDAO;
            _violazioneDAO = violazioneDAO;
        }

        public IActionResult Create()
        {
            var anagrafiche = _anagraficaDAO.GetAll();
            var violazioni = _violazioneDAO.GetAll();

            ViewBag.Anagrafiche = anagrafiche;
            ViewBag.Violazioni = violazioni;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Verbale verbale, List<int> violazioniSelezionate)
        {
            if (ModelState.IsValid)
            {
                _verbaleDAO.Add(verbale);
                int idVerbale = _verbaleDAO.GetLastInsertedId();

                foreach (var idViolazione in violazioniSelezionate)
                {
                    _violazioniAVerbaleDAO.Add(new ViolazioniAVerbale
                    {
                        IdVerbaleFK = idVerbale,
                        IdViolazioneFK = idViolazione
                    });
                }

                return RedirectToAction("Index", "Home");
            }

            var anagrafiche = _anagraficaDAO.GetAll();
            var violazioni = _violazioneDAO.GetAll();

            ViewBag.Anagrafiche = anagrafiche;
            ViewBag.Violazioni = violazioni;

            return View(verbale);
        }
    }
}
