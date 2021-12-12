using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Diagnostics;
using TrainingPortal.WebPL.Models;

namespace TrainingPortal.WebPL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger logger;

        public HomeController(ILogger logger)
        {
            this.logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AccessDenied()
        {
            logger.Warning($"Access denied: initiator = \"{User.Identity.Name}\"");

            return View();
        }

        public IActionResult NotImplemented()
        {
            logger.Debug($"Requested page with not implemented feature: initiator = \"{User.Identity.Name}\"");

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}