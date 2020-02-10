using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Data.Entities
{
    public class Evento
    {
        public int Id { get; set; }
    
        [Required]
        public string Nome { get; set; }
    
        [Required]
        public string Localita { get; set; }
    
        [Required]
        public DateTime Data { get; set; }
        public string Descrizione { get; set; }
        public string Note { get; set; }
    }
}