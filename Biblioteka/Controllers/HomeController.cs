using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Biblioteka.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Identity;

namespace Biblioteka.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser>
            _userManager;

        private Task<IdentityUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public HomeController (UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var user = GetCurrentUserAsync().GetAwaiter().GetResult();

            if (User.Identity.IsAuthenticated && !_userManager.IsInRoleAsync(user, "Verified").GetAwaiter().GetResult())
            {
                return RedirectToAction("Create", "Uzytkownicies");
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = User.Identity;
            ViewData["ids"] = User.Identities.First();

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
