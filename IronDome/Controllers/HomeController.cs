using IronDome.DAL;
using IronDome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace IronDome.Controllers
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
            //var defenceAmmunitions = Data.Get.DefenceAmmunitions.ToList();
            //var terrorOrgs = Data.Get.TerrorOrgs.ToList();
            //var threats = Data.Get.Threats.Include(t => t.Org).Include(t => t.type).ToList();
            //var threatAmmunitions = Data.Get.ThreatAmmunitions.ToList();

            ////var model = new HomeViewModel
            ////{
            ////    DefenceAmmunitions = defenceAmmunitions,
            ////    TerrorOrgs = terrorOrgs,
            ////    Threats = threats,
            ////    ThreatAmmunitions = threatAmmunitions
            ////};

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
