using ChoixSejour.Models;
using System;
using System.Collections.Generic;

namespace ChoixSejour.ViewModels
{
    public class HomeViewModel
    {
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public Sejour Sejour { get; set; }
        public List<String> ListPrenoms { get; set; }
        public List<Utilisateur> ListUtilisateurs { get; set; }
    }
}
