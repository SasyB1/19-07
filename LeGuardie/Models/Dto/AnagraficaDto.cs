using System.ComponentModel.DataAnnotations;

namespace LeGuardie.Models.Dto
{
    public class AnagraficaDto
    {
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
 
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Il CAP deve essere esattamente di 5 cifre e deve contenere solo numeri.")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Il CAP deve essere esattamente di 5 cifre e deve contenere solo numeri.")]
        public string CAP { get; set; }

        [StringLength(16, MinimumLength = 16, ErrorMessage = "Il Codice Fiscale deve essere esattamente di 16 caratteri.")]
        public string CodiceFiscale { get; set; }
    }
}
