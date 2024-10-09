using ChoixSejour.Models;
using ChoixSejour.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ChoixSejour.Controllers
{
    public class AccomodationController : Controller
    {
        public IActionResult VoyagePrevu()
        {
            Sejour sejour = new Sejour { Lieu = "Toulouse", Telephone = "0676618598" };
            Utilisateur utilisateur = new Utilisateur { Prenom = "Vincent" };

            VoyagePrevuViewModel model = new VoyagePrevuViewModel()
            {
                Utilisateur = utilisateur,
                Sejour = sejour
            };

            return View(model);
        }
    }
}
