using Microsoft.AspNetCore.Mvc;
using Esercitazione_14.Models;
using System.Collections.Generic;
using System.Linq;

namespace Esercitazione_14.Controllers
{
    public class ProdottiController : Controller
    {
        private static List<Prodotto> prodotti = new List<Prodotto>
        {
            new Prodotto { Id = 1, Nome = "Scarpe A", Prezzo = 50.0m, Descrizione = "Descrizione delle Scarpe A", ImmagineCopertina = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS-bdz0d4N_RanOpn2K_AGY6-Uyc26T0SZcAw&s", ImmagineAggiuntiva1 = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS-bdz0d4N_RanOpn2K_AGY6-Uyc26T0SZcAw&s", ImmagineAggiuntiva2 = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS-bdz0d4N_RanOpn2K_AGY6-Uyc26T0SZcAw&s" },
            new Prodotto { Id = 2, Nome = "Scarpe B", Prezzo = 75.0m, Descrizione = "Descrizione delle Scarpe B", ImmagineCopertina = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS-bdz0d4N_RanOpn2K_AGY6-Uyc26T0SZcAw&s", ImmagineAggiuntiva1 = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS-bdz0d4N_RanOpn2K_AGY6-Uyc26T0SZcAw&s", ImmagineAggiuntiva2 = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS-bdz0d4N_RanOpn2K_AGY6-Uyc26T0SZcAw&s" }
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
