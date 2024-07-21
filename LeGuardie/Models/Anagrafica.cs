using System.ComponentModel.DataAnnotations;

namespace LeGuardie.Models
{
    public class Anagrafica
    {
        public int IdUtente { get; set; }

        public string Cognome { get; set; }
        public string Nome { get; set; }      
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public string CAP { get; set; }     
        public string CodiceFiscale { get; set; }
    }
}
