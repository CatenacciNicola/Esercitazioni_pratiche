using Esercitazione_17.Data;
using Esercitazione_17.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Esercitazione_17.Controllers
{
    [Authorize]
    public class PrenotazioniController : Controller
    {
        private readonly ClienteDao _clienteDao;
        private readonly CameraDao _cameraDao;
        private readonly TrattamentoDao _trattamentoDao;
        private readonly PrenotazioneDao _prenotazioneDao;
        private readonly ServizioDao _servizioDao;
        private readonly PrenotazioneServizioDao _prenotazioneServizioDao;


        public PrenotazioniController(ClienteDao clienteDao, CameraDao cameraDao, TrattamentoDao trattamentoDao, PrenotazioneDao prenotazioneDao, ServizioDao servizioDao, PrenotazioneServizioDao prenotazioneServizioDao)
        {
            _clienteDao = clienteDao;
            _cameraDao = cameraDao;
            _trattamentoDao = trattamentoDao;
            _prenotazioneDao = prenotazioneDao;
            _servizioDao = servizioDao;
            _prenotazioneServizioDao = prenotazioneServizioDao;
        }

        public IActionResult Prenotazioni()
        {
            ViewBag.Clienti = _clienteDao.GetAllClienti();
            ViewBag.Camere = _cameraDao.GetAllCamere();
            ViewBag.Trattamenti = _trattamentoDao.GetAllTrattamenti();
            return View();
        }

        [HttpPost]
        public IActionResult AddPrenotazione(SalvaPrenotazione prenotazione)
        {
            if (prenotazione.Dal < DateTime.Today)
            {
                ModelState.AddModelError("Dal", "La data di CheckIn deve essere dal giorno corrente in poi.");
            }

            if (prenotazione.Al <= prenotazione.Dal)
            {
                ModelState.AddModelError("Al", "La data di CheckOut deve essere successiva alla data del CheckIn.");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Clienti = _clienteDao.GetAllClienti();
                ViewBag.Camere = _cameraDao.GetAllCamere();
                ViewBag.Trattamenti = _trattamentoDao.GetAllTrattamenti();
                return View("Prenotazioni");
            }

            var camera = _cameraDao.GetCameraByNumero(prenotazione.NumeroCamera);
            var trattamento = _trattamentoDao.GetTrattamentoById(prenotazione.TrattamentoId);

            if (camera == null || trattamento == null)
            {
                return BadRequest("Invalid camera or treatment selection");
            }

            int numeroGiorni = (prenotazione.Al - prenotazione.Dal).Days;
            prenotazione.TariffaApplicata = (camera.TariffaBase + trattamento.TariffaSupplementare) * numeroGiorni;
            prenotazione.DataPrenotazione = DateTime.Now;
            prenotazione.Anno = DateTime.Now.Year;
            prenotazione.NumeroProgressivoAnno = DateTime.Now.Year - 2023;

            _prenotazioneDao.AddPrenotazione(prenotazione);
            return RedirectToAction("Prenotazioni");
        }
        public IActionResult ElencoPrenotazioni()
        {
            var prenotazioni = _prenotazioneDao.GetAllPrenotazioni();
            return View(prenotazioni);
        }

        public IActionResult Servizi(int id)
        {
            var prenotazione = _prenotazioneDao.GetPrenotazioneById(id);
            if (prenotazione == null)
            {
                return NotFound();
            }

            ViewBag.Servizi = _servizioDao.GetAllServizi();
            ViewBag.Prenotazione = prenotazione;
            var serviziPrenotazione = _prenotazioneServizioDao.GetServiziByPrenotazioneId(id);
            return View(serviziPrenotazione);
        }

        [HttpPost]
        public IActionResult AddServizioPrenotazione(PrenotazioneServizio prenotazioneServizio)
        {
            var servizio = _servizioDao.GetServizioById(prenotazioneServizio.IdServizio);
            if (servizio == null)
            {
                return BadRequest("Servizio non valido.");
            }

            prenotazioneServizio.Data = DateTime.Now;
            prenotazioneServizio.Prezzo = servizio.Prezzo * prenotazioneServizio.Quantita;

            _prenotazioneServizioDao.AddServizioPrenotazione(prenotazioneServizio);
            return RedirectToAction("Servizi", new { id = prenotazioneServizio.IdPrenotazione });
        }

        //Da qui
        public IActionResult CheckOut(int id)
        {
            var prenotazione = _prenotazioneDao.GetPrenotazioneById(id);
            if (prenotazione == null)
            {
                return NotFound();
            }

            var serviziPrenotazione = _prenotazioneServizioDao.GetServiziByPrenotazioneId(id);
            decimal totaleServizi = 0;
            foreach (var servizio in serviziPrenotazione)
            {
                totaleServizi += servizio.Prezzo;
            }

            ViewBag.Prenotazione = prenotazione;
            ViewBag.ServiziPrenotazione = serviziPrenotazione;
            ViewBag.TotaleServizi = totaleServizi;
            ViewBag.TotaleDaSaldare = prenotazione.TariffaApplicata - prenotazione.CaparraConfirmatoria + totaleServizi;

            return View();
        }
        //A qui
    }
}
