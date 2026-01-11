using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaraAPI.Models
{
    public class Proprietar
    {
        public int ProprietarId { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Numele trebuie să aibă între 3 și 50 de caractere.")]
        [Display(Name = "Nume de Familie")] 
        public string Nume { get; set; } = null!;

        [Required(ErrorMessage = "Prenumele este obligatoriu.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Prenumele trebuie să aibă între 3 și 50 de caractere.")]
        public string Prenume { get; set; } = null!;

        [Required(ErrorMessage = "Telefonul este obligatoriu.")]
        [RegularExpression(@"^07\d{8}$", ErrorMessage = "Numărul trebuie să fie de forma 07xxxxxxxx (10 cifre).")]
        public string Telefon { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Adresa de email nu este validă.")]
        public string? Email { get; set; }

        [StringLength(200, ErrorMessage = "Adresa nu poate depăși 200 de caractere.")]
        public string? Adresa { get; set; }

        public DateTime DataCreare { get; set; } = DateTime.UtcNow;

        public List<Animal> Animale { get; set; } = new();
    }
}