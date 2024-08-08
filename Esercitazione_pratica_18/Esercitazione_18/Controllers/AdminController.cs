using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Esercitazione_18.Models;
using System.Linq;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;


namespace Esercitazione_18.Controllers
{
    [Authorize(Roles = "Admin")] // Autorizzo solo gli utenti con ruolo Admin
    public class AdminController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AdminController(DataContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            // Recupero il nome dell'utente autenticato e lo passo alla vista
            var userName = User.FindFirstValue(ClaimTypes.Name);
            ViewBag.UserName = userName;
            return View();
        }

        [HttpGet]
        public IActionResult AggiungiIngrediente()
        {
            // Restituisco la vista per aggiungere un nuovo ingrediente
            return View();
        }

        [HttpPost]
        public IActionResult AggiungiIngrediente(Ingredient ingredient)
        {
            // Aggiungo l'ingrediente al database e salvo le modifiche
            _context.Ingredients.Add(ingredient);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AggiungiProdotto()
        {
            // Recupero tutti gli ingredienti e li passo alla vista
            ViewBag.Ingredients = _context.Ingredients.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AggiungiProdotto(Product product, IFormFile file, List<int> ingredientIds)
        {
            // Gestisco il caricamento dell'immagine del prodotto
            if (file != null)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                product.ProductImage = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/images/", fileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }

            // Associo gli ingredienti selezionati al prodotto e salvo nel database
            product.Ingredients = _context.Ingredients.Where(i => ingredientIds.Contains(i.IngredientId)).ToList();
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult VisualizzaOrdini()
        {
            // Recupero tutti gli ordini con i dettagli dei prodotti inclusi e li passo alla vista
            var orders = _context.Orders.Include(o => o.Products).ThenInclude(oi => oi.Product).ToList();
            return View(orders);
        }

        [HttpPost]
        public IActionResult AggiornaProcessed(int orderId)
        {
            // Trovo l'ordine specificato e aggiorno il campo Processed a true
            var order = _context.Orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order != null)
            {
                order.Processed = true;
                _context.SaveChanges();
            }
            return RedirectToAction("VisualizzaOrdini");
        }
    }
}
