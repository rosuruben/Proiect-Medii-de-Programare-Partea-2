using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace ClinicaVeterinaraAPI.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }

        [Display(Name = "Nume Proprietar")]
        public int ProprietarId { get; set; }

        [NotMapped] 
        [Display(Name = "Nume Proprietar")]
        public string? NumeProprietar { get; set; }

        [Required(ErrorMessage = "Numele este obligatoriu.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Numele trebuie să aibă între 2 și 50 de caractere.")]
        public string Nume { get; set; } = null!;

        [Required(ErrorMessage = "Specia este obligatorie.")]
        [StringLength(30, ErrorMessage = "Specia nu poate depăși 30 de caractere.")]
        public string Specie { get; set; } = null!;

        [StringLength(50, ErrorMessage = "Rasa nu poate depăși 50 de caractere.")]
        public string? Rasa { get; set; }

        [StringLength(15, ErrorMessage = "Sexul nu poate depăși 15 caractere.")]
        public string? Sex { get; set; }

        [Required(ErrorMessage = "Data nașterii este obligatorie.")]
        [DataType(DataType.Date)]
        public DateTime DataNasterii { get; set; }

        [StringLength(20, ErrorMessage = "Microcipul nu poate depăși 20 de caractere.")]
        public string? Microcip { get; set; }

        [StringLength(500, ErrorMessage = "Observațiile nu pot depăși 500 de caractere.")]
        public string? Observatii { get; set; }

        public Proprietar Proprietar { get; set; } = null!;
        public List<Programare> Programari { get; set; } = new();
    }
}