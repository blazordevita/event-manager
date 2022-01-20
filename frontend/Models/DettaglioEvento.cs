using System;
using System.ComponentModel.DataAnnotations;

namespace frontend.Models
{
    public class DettaglioEvento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il nome è obbligatorio!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "La località è obbligatoria!")]
        public string Localita { get; set; }

        [Required(ErrorMessage = "La data è obbligatorio!")]
        public DateTime Data { get; set; }
        public string Descrizione { get; set; }
        public string Note { get; set; }
    }
}