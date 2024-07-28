namespace Esercitazione_17.Models
{
    public class PrenotazioneServizio
    {
        public int Id { get; set; }
        public int IdPrenotazione { get; set; }
        public int IdServizio { get; set; }
        public string DescrizioneServizio { get; set; } // Aggiungi questa proprietà
        public DateTime Data { get; set; }
        public int Quantita { get; set; }
        public decimal Prezzo { get; set; }
    }
}
