using System.ComponentModel.DataAnnotations;

namespace Esercitazione_14.Models
{
    public class Prodotto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il nome è obbligatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Il prezzo è obbligatorio")]
        [Range(0.01, 10000.00, ErrorMessage = "Il prezzo deve essere tra 0.01 e 10000.00")]
        public decimal Prezzo { get; set; }

        [Required(ErrorMessage = "La descrizione è obbligatoria")]
        public string Descrizione { get; set; }

        [Required(ErrorMessage = "L'immagine di copertina è obbligatoria")]
        public string ImmagineCopertina { get; set; }

        public string ImmagineAggiuntiva1 { get; set; }
        public string ImmagineAggiuntiva2 { get; set; }
    }
}
