using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Esercitazione_18.Models;

namespace Esercitazione_18.Controllers
{
    [Authorize(Roles = "Admin")] // Autorizzo solo gli utenti con ruolo Admin
    public class ReportsController : Controller
    {
        private readonly DataContext _context;

        public ReportsController(DataContext context)
        {
            _context = context;
        }

        // Restituisco la vista per la pagina dei report
        public IActionResult Index()
        {
            return View();
        }

        // Endpoint per ottenere il numero totale di ordini evasi
        [HttpGet]
        public async Task<IActionResult> GetTotalOrdersProcessed()
        {
            // Calcolo il numero totale di ordini evasi
            var totalOrdersProcessed = await _context.Orders.CountAsync(o => o.Processed);
            // Restituisco il risultato come JSON
            return Json(totalOrdersProcessed);
        }

        // Endpoint per ottenere il totale incassato per una determinata data
        [HttpGet]
        public async Task<IActionResult> GetTotalRevenueByDate(DateTime date)
        {
            // Calcolo il totale incassato per la data specificata, considerando solo gli ordini evasi
            var totalRevenue = await _context.Orders
                .Where(o => o.Date.Date == date.Date && o.Processed)
                .SelectMany(o => o.Products)
                .SumAsync(oi => oi.Product.Price * oi.Quantity);

            // Restituisco il risultato
            return Json(totalRevenue);
        }
    }
}
