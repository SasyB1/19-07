using System.ComponentModel.DataAnnotations;

namespace LeGuardie.Models.Dto
{
    public class VerbaleDto
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }       
        public string Descrizione { get; set; }
        public int TotaleVerbali { get; set; }
        public int IdVerbale { get; set; }
        public int IdUtente { get; set; }
        public int IdViolazione { get; set; }
        public DateTime DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; }
        public string NomeAgente { get; set; }
        public DateTime DataTrascrizione { get; set; }
        public decimal Importo { get; set; }
        public int PuntiDecurtati { get; set; }

    }
}
