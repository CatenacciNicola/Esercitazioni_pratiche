namespace ContravvenzioniWebApp.Models
{
    public class ViolazioniAVerbale
    {
        public int IdViolazioniAVerbale { get; set; }
        public int IdVerbaleFK { get; set; }
        public int IdViolazioneFK { get; set; }
    }

}
