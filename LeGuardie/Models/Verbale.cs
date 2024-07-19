using System.ComponentModel.DataAnnotations;

namespace LeGuardie.Models
{
    public class Verbale
    {
        public int IdVerbale { get; set; }
        public int IdUtente { get; set; }
        public int IdViolazione { get; set; }
        public DateTime DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; }
        public string NomeAgente { get; set; }
        public DateTime DataTrascrizione { get; set; }

        [Range(0, 1000000, ErrorMessage = "L'importo deve essere un valore tra 0 e 1.000.000.")]
        public decimal Importo { get; set; }

        [Range(1, 30, ErrorMessage = "I punti decurtati devono essere un valore tra 1 e 30.")]
        public int PuntiDecurtati { get; set; }
    }
}
