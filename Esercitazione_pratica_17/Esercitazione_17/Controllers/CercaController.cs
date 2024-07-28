using Esercitazione_17.Data;
using Esercitazione_17.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Esercitazione_17.Controllers
{
    public class CercaController : Controller
    {
        private readonly CercaDao _cercaDao;

        public CercaController(CercaDao cercaDao)
        {
            _cercaDao = cercaDao;
        }

        public IActionResult Cerca()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CercaPrenotazioni(string codiceFiscale)
        {
            var prenotazioni = _cercaDao.GetPrenotazioniByCodiceFiscale(codiceFiscale);
            return PartialView("_PrenotazioniResult", prenotazioni);
        }

        [HttpPost]
        public IActionResult ContaPensioneCompleta()
        {
            int numeroPrenotazioni = _cercaDao.GetNumeroPrenotazioniPensioneCompleta();
            return PartialView("_ContaResult", numeroPrenotazioni);
        }
    }
}
