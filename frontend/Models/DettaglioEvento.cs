using System;

namespace frontend.Models
{
    public class DettaglioEvento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Localita { get; set; }
        public DateTime Data { get; set; }
        public string Descrizione { get; set; }
        public string Note { get; set; }
    }
}