using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TranslatorApp.Models;

namespace TranslatorApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Translator()
        {
            return View("~/Views/Translator/Translator.cshtml");
        }

        public IActionResult Admin()
        {
            return View();
        }
        public IActionResult AdminLogin(adminloginmodel adminloginmodel)
        {
            if (adminloginmodel != null)
            {
                if (adminloginmodel.username == "adminwords" && adminloginmodel.password == "admin123word")
                {
                    return RedirectToAction("AdminPage","Admin");
                }
                else
                {
                    ViewBag.ErrorMessage = "Məlumatları düzgün daxil edin!";
                    return View("Admin");
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Məlumatları düzgün daxil edin!";
                return View("Admin");
            }

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}