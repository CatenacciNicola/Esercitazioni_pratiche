using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Esercitazione_18.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Esercitazione_18.Controllers
{
    public class AccountController : Controller
    {
        private readonly DataContext _context;

        public AccountController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            // Restituisco la vista per il login
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            // Controllo che email e password corrispondano a un utente nel database
            var user = _context.Users
                               .Include(u => u.Roles)
                               .SingleOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                // Creo i claims per l'utente autenticato
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Roles.First().RoleName)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Eseguo il login dell'utente
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                // Reindirizzo l'utente in base al suo ruolo
                if (user.Roles.Any(r => r.RoleName == "Admin"))
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (user.Roles.Any(r => r.RoleName == "Client"))
                {
                    return RedirectToAction("Acquista", "Client");
                }
            }

            // Mostro un messaggio di errore se l'autenticazione fallisce
            ViewBag.Error = "Invalid email or password";
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            // Restituisco la vista per la registrazione
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                // Assegno il ruolo di Client all'utente
                user.Roles.Add(_context.Roles.SingleOrDefault(r => r.RoleId == 2)); // Client role
                // Aggiungo l'utente al database
                _context.Users.Add(user);
                _context.SaveChanges();
                // Reindirizzo l'utente alla pagina di login
                return RedirectToAction("Login");
            }

            // Restituisco la vista di registrazione in caso di errore
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            // Eseguo il logout dell'utente
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            // Reindirizzo l'utente alla pagina di login
            return RedirectToAction("Login");
        }

        
    }
}
