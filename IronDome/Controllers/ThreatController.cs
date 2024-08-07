using IronDome.DAL;
using IronDome.Models;
using IronDome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IronDome.Controllers
{
    public class ThreatController : Controller
    {
        public IActionResult Index()
        {
            List<Threat> threats = Data.Get.Threats
            .Include(t => t.Org)
            .Include(t => t.type)
            .ToList();
            return View(threats);
        }

        public IActionResult Create()
        {

            List<ThreatAmmunition>? ta = Data.Get.ThreatAmmunitions.ToList();
            List<TerrorOrg>? orgList = Data.Get.TerrorOrgs.ToList();

            CreateThreatViewModel model = new CreateThreatViewModel
            {
                Types = ta.Select(t => new SelectListItem { Value = t.id.ToString(), Text = t.name }).ToList(),
                TerrorOrgs = orgList.Select(t => new SelectListItem { Value = t.id.ToString(), Text = t.name }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateThreatViewModel model)
        {
            TerrorOrg? org = Data.Get.TerrorOrgs.Find(model.OrgId);
            ThreatAmmunition? threatType = Data.Get.ThreatAmmunitions.Find(model.ThreatTypeId);

            if (org != null && threatType != null)
            {
                Threat newThreat = new Threat
                {
                    Org = org,
                    type = threatType,
                };

                Data.Get.Threats.Add(newThreat);
                Data.Get.SaveChanges();

                Task.Run(() => StartAttack(newThreat));

            }


            return RedirectToAction(nameof(Index));
        }

        private void StartAttack(Threat threat)
        {
            Console.WriteLine($"Threat {threat.id} from {threat.Org.name} with {threat.type.name} started.");
            threat.status = ThreatStatus.Active; // Mark threat as inactive after attack
            Task.Delay(threat.responseTime * 1000).Wait(); // Simulate time delay for response time
            Console.WriteLine($"Threat {threat.id} attack finished.");

            // Update the threat status in the database
            Threat? existingThreat = Data.Get.Threats.Find(threat.id);
            if (existingThreat != null)
            {
                existingThreat.status = ThreatStatus.Active;
                Data.Get.SaveChanges();
            }
        }
    }
}
