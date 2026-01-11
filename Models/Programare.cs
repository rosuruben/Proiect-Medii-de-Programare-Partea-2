using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace ClinicaVeterinaraAPI.Models
{
    public enum StatusProgramare
    {
        Programata = 0,
        Finalizata = 1,
        Anulata = 2
    }

    public class Programare
    {
        public int ProgramareId { get; set; }

        public int AnimalId { get; set; }
        public int MedicVeterinarId { get; set; }

        [Required(ErrorMessage = "Data și ora sunt obligatorii.")]
        [DataType(DataType.DateTime)]
        public DateTime DataOra { get; set; }

        [Required(ErrorMessage = "Motivul programării este obligatoriu.")]
        [StringLength(200, ErrorMessage = "Motivul nu poate depăși 200 de caractere.")]
        public string Motiv { get; set; } = null!;

        [Required(ErrorMessage = "Statusul este obligatoriu.")]
        public StatusProgramare Status { get; set; } = StatusProgramare.Programata;

        public DateTime DataCreare { get; set; } = DateTime.UtcNow;

        public Animal Animal { get; set; } = null!;
        public MedicVeterinar MedicVeterinar { get; set; } = null!;
        public Recenzie? Recenzie { get; set; }
    }
}