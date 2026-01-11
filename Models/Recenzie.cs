using System;
using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinaraAPI.Models
{
    public class Recenzie
    {
        public int RecenzieId { get; set; }

        public int? ProgramareId { get; set; }
        public int MedicVeterinarId { get; set; }
        public int ProprietarId { get; set; }

        [Required(ErrorMessage = "Trebuie să acordați o notă.")]
        [Range(1, 5, ErrorMessage = "Nota trebuie să fie între 1 și 5.")]
        public int Rating { get; set; }

        [StringLength(500, ErrorMessage = "Comentariul nu poate depăși 500 de caractere.")]
        public string? Comentariu { get; set; }

        public Proprietar Proprietar { get; set; }
        public DateTime DataCreare { get; set; } = DateTime.UtcNow;

        public Programare? Programare { get; set; }
        public MedicVeterinar MedicVeterinar { get; set; }
    }
}