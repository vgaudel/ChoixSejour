using ChoixSejour.Models;
using ChoixSejour.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ChoixSejour.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Sejour sejour = new Sejour { Lieu = "Chambord", Telephone = "11111111" };
            List<string> ListPrenoms = new List<string>();

            using (Dal dal = new Dal())
            {
                List<Utilisateur> mesUtilisateurs = dal.ObtientTousLesUtilisateurs();
                foreach (Utilisateur u in mesUtilisateurs)
                {
                    ListPrenoms.Add(u.Prenom);
                }


                HomeViewModel hvm = new HomeViewModel
                {
                    Message = "Bonjour tout le monde",
                    Date = DateTime.Now,
                    Sejour = sejour,
                    ListPrenoms = ListPrenoms,
                    ListUtilisateurs = mesUtilisateurs                   
                };

                return View(hvm);
            }
        }
    }
}
