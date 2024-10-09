using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChoixSejour.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        [MaxLength(25)]
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Password { get; set; }

        //public string Role { get; set; }
    }
}
