using _3SLoginPage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using _3SLoginPage.Repository;

namespace _3SLoginPage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private LoginRepo login_repo = new LoginRepo();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection collection)
        {
            string noti = string.Empty;
            string result = login_repo.isLogin(collection);
            switch (result)
            {
                case "t":
                    return RedirectToAction("Privacy");
                case "f":
                    noti = "Login failed. You may have entered the wrong username or password.";
                    break;
                default:
                    noti = result;
                    break;

            }
            TempData["Error"] = noti;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
