using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaraAPI.Models
{
    public class MedicVeterinar
    {
        public int MedicVeterinarId { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Numele trebuie să aibă între 3 și 50 de caractere.")]
        [Display(Name = "Nume")]
        public string Nume { get; set; } = null!;

        [Required(ErrorMessage = "Prenumele este obligatoriu.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Prenumele trebuie să aibă între 3 și 50 de caractere.")]
        public string Prenume { get; set; } = null!;

        [StringLength(100, ErrorMessage = "Specializarea nu poate depăși 100 de caractere.")]
        public string? Specializare { get; set; }

        [StringLength(20, ErrorMessage = "Telefonul nu poate depăși 20 de caractere.")]
        [Phone(ErrorMessage = "Număr de telefon invalid.")]
        public string? Telefon { get; set; }

        [StringLength(100, ErrorMessage = "Email-ul nu poate depăși 100 de caractere.")]
        [EmailAddress(ErrorMessage = "Adresa de email nu este validă.")]
        public string? Email { get; set; }

        public List<Programare> Programari { get; set; } = new();
        public List<Recenzie> Recenzii { get; set; } = new();
    }
}