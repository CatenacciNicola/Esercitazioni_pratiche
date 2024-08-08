using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Esercitazione_18.Models;
using Microsoft.EntityFrameworkCore;

namespace Esercitazione_18.Controllers
{
    [Authorize(Roles = "Client")] // Autorizzo solo gli utenti con ruolo Client
    public class ClientController : Controller
    {
        private readonly DataContext _context;

        public ClientController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Acquista()
        {
            // Restituisco la vista per l'acquisto
            return View();
        }

        [HttpPost]
        public IActionResult CreaOrdine(string address, string notes)
        {
            // Creo un nuovo ordine con l'indirizzo e le note forniti
            var order = new Order
            {
                Address = address,
                Notes = notes,
                Processed = false,
                Date = DateTime.Now
            };

            // Aggiungo l'ordine al database e salvo le modifiche
            _context.Orders.Add(order);
            _context.SaveChanges();

            // Reindirizzo alla pagina per selezionare i prodotti per l'ordine
            return RedirectToAction("SelezionaProdotti", new { orderId = order.OrderId });
        }

        public IActionResult SelezionaProdotti(int orderId)
        {
            // Recupero l'ordine specificato con i dettagli dei prodotti inclusi
            var order = _context.Orders.Include(o => o.Products).ThenInclude(oi => oi.Product).FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                return NotFound();
            }

            // Passo l'ID dell'ordine e gli ID dei prodotti esistenti alla vista
            ViewBag.OrderId = orderId;
            var products = _context.Products.ToList();
            var existingProductIds = order.Products.Select(op => op.ProductId).ToList();
            ViewBag.ExistingProductIds = existingProductIds;

            // Restituisco la vista per selezionare i prodotti
            return View(products);
        }

        [HttpPost]
        public IActionResult AggiungiProdotto(int orderId, int productId, int quantity)
        {
            // Recupero l'ordine specificato
            var order = _context.Orders.Include(o => o.Products).FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                return NotFound();
            }

            // Verifico se il prodotto è già presente nell'ordine
            var existingProduct = order.Products.FirstOrDefault(op => op.ProductId == productId);
            if (existingProduct != null)
            {
                // Incremento la quantità se il prodotto è già presente
                existingProduct.Quantity += quantity;
            }
            else
            {
                // Aggiungo il nuovo prodotto all'ordine
                order.Products.Add(new OrderItem
                {
                    ProductId = productId,
                    Quantity = quantity,
                    Order = order
                });
            }

            // Salvo le modifiche nel database
            _context.SaveChanges();

            // Reindirizzo alla pagina per selezionare i prodotti
            return RedirectToAction("SelezionaProdotti", new { orderId = orderId });
        }

        public IActionResult RecapitoOrdine(int orderId)
        {
            // Recupero l'ordine specificato con i dettagli dei prodotti inclusi
            var order = _context.Orders.Include(o => o.Products).ThenInclude(oi => oi.Product).FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                return NotFound();
            }

            // Restituisco la vista per il recapito dell'ordine
            return View(order);
        }

        [HttpPost]
        public IActionResult ModificaQuantita(int orderId, int orderItemId, int quantity)
        {
            // Recupero l'articolo dell'ordine specificato
            var orderItem = _context.OrderItems.FirstOrDefault(oi => oi.OrderItemId == orderItemId);
            if (orderItem == null)
            {
                return NotFound();
            }

            // Modifico la quantità dell'articolo
            orderItem.Quantity = quantity;
            _context.SaveChanges();

            // Reindirizzo alla pagina di recapito dell'ordine
            return RedirectToAction("RecapitoOrdine", new { orderId = orderId });
        }

        [HttpPost]
        public IActionResult EliminaOrdine(int orderId)
        {
            // Recupero l'ordine specificato con i dettagli dei prodotti inclusi
            var order = _context.Orders.Include(o => o.Products).FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                return NotFound();
            }

            // Rimuovo l'ordine dal database e salvo le modifiche
            _context.Orders.Remove(order);
            _context.SaveChanges();

            // Reindirizzo alla pagina di acquisto
            return RedirectToAction("Acquista");
        }
    }
}
