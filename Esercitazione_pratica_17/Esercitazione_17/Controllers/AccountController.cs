using Esercitazione_17.Data;
using Esercitazione_17.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Esercitazione_17.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserDao _userDao;

        public AccountController(UserDao userDao)
        {
            _userDao = userDao;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = _userDao.GetUserByUsername(username);

            if (user != null && user.Password == password)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMessage = "Invalid login attempt";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }

}

