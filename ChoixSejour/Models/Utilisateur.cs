using System.ComponentModel.DataAnnotations;

namespace ChoixSejour.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        [Required]
        public string Prenom { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
