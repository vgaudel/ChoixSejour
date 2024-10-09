using System.ComponentModel.DataAnnotations;

namespace ChoixSejour.Models
{
    public class Sejour
    {
        public int Id { get; set; }
        [MaxLength(25)]
        [Required(ErrorMessage = "Merci de renseigner un lieu")]
        public string Lieu { get; set; }
        [Display(Name = "Numéro de Téléphone")]
        [MaxLength(12)]
        [Required(ErrorMessage = "Merci de renseigner un contact téléphonique")]
        public string Telephone { get; set; }
    }
}
