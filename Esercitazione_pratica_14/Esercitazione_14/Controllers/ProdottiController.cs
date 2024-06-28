using Esercitazione_14.Models;
using Microsoft.AspNetCore.Mvc;

namespace Esercitazione_14.Controllers
{
    public class ProdottiController : Controller
    {
        private static List<Prodotto> prodotti = new List<Prodotto>
        {
            new Prodotto { Id = 1, Nome = "Scarpe A", Prezzo = 50.0m, Descrizione = "Descrizione delle Scarpe A", ImmagineCopertina = "cover1.jpg", ImmagineAggiuntiva1 = "additional1a.jpg", ImmagineAggiuntiva2 = "additional1b.jpg" },
            new Prodotto { Id = 2, Nome = "Scarpe B", Prezzo = 75.0m, Descrizione = "Descrizione delle Scarpe B", ImmagineCopertina = "cover2.jpg", ImmagineAggiuntiva1 = "additional2a.jpg", ImmagineAggiuntiva2 = "additional2b.jpg" }
        };

        public IActionResult Index()
        {
            return View(prodotti);
        }

        public IActionResult Dettagli(int id)
        {
            var prodotto = prodotti.Find(p => p.Id == id);
            if (prodotto == null)
            {
                return NotFound();
            }
            return View(prodotto);
        }

        public IActionResult Crea()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crea(Prodotto prodotto)
        {
            if (ModelState.IsValid)
            {
                prodotto.Id = prodotti.Count > 0 ? prodotti.Max(p => p.Id) + 1 : 1; // Genera un nuovo Id
                prodotti.Add(prodotto);
                return RedirectToAction(nameof(Index));
            }
            return View(prodotto);
        }
    }
}