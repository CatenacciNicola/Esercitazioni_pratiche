namespace Esercitazione_17.Models
{
    public class Prenotazione
    {
        public int Id { get; set; }
        public string CodiceFiscaleCliente { get; set; }
        public string NomeCliente { get; set; }
        public string CognomeCliente { get; set; }
        public int NumeroCamera { get; set; }
        public string DescrizioneCamera { get; set; }
        public string TipologiaCamera { get; set; }
        public string DescrizioneTrattamento { get; set; }
        public DateTime Dal { get; set; }
        public DateTime Al { get; set; }
        public DateTime DataPrenotazione { get; set; }
        public int NumeroProgressivoAnno { get; set; }
        public int Anno { get; set; }
        public decimal CaparraConfirmatoria { get; set; }
        public decimal TariffaApplicata { get; set; }
        public int TrattamentoId { get; set; }
    }
}
