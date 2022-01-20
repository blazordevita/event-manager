using System;
using System.ComponentModel.DataAnnotations;

namespace frontend.Models
{
    public class DettaglioEvento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il nome � obbligatorio!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "La localit� � obbligatoria!")]
        public string Localita { get; set; }

        [Required(ErrorMessage = "La data � obbligatorio!")]
        public DateTime Data { get; set; }
        public string Descrizione { get; set; }
        public string Note { get; set; }
    }
}