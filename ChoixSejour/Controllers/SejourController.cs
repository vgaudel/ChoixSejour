using ChoixSejour.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ChoixSejour.Controllers
{
    [Authorize]
    public class SejourController : Controller
    {
        public IActionResult ModifierSejour(int id)
        {
            if (id != 0)
            {
                using (IDal dal = new Dal())
                {
                    Sejour sejour = dal.ObtientTousLesSejours().Where(r => r.Id == id).FirstOrDefault();
                    if (sejour == null)
                    {
                        return View("Error", new Sejour { Id = 0 });
                    }
                    return View(sejour);
                }
            }
            return View("Error", new Sejour { Id=0 });
        }

        [HttpPost]
        public IActionResult ModifierSejour(Sejour sejour)
        {
            if (!ModelState.IsValid)
                return View(sejour);

            if (sejour.Id != 0)
            {
                using (Dal dal = new Dal())
                {
                    dal.ModifierSejour(sejour.Id, sejour.Lieu, sejour.Telephone);
                    return RedirectToAction("ModifierSejour", new { @id = sejour.Id });
                }
            }
            else
            {
                return View("Error", sejour);
            }
        }

    }
}
