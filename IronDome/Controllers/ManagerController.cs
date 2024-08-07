using IronDome.DAL;
using IronDome.Models;
using Microsoft.AspNetCore.Mvc;

namespace IronDome.Controllers
{
    public class ManagerController : Controller
    {
        public IActionResult Index()
        {
            return View(Data.Get.DefenceAmmunitions.ToList());
        }

        public IActionResult updateDefenceAmmunition(int dfid, int amount)
        {
            DefenceAmmunition? da = Data.Get.DefenceAmmunitions.Find(dfid);
            if (da == null) return NotFound();
            da.amount = amount;
            Data.Get.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
