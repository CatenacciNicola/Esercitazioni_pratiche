using System.Globalization;

namespace Esercitazione_11 //Esercitazione pratica 13, mi sono accorta solo dopo aver caricato su git di aver sbagliato il conteggio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CHIEDO ALL'UTENTE DI INSERIRE I DATI
            Console.Write("Inserisci il nome: ");
            string nome = Console.ReadLine();

            Console.Write("Inserisci il cognome: ");
            string cognome = Console.ReadLine();

            //LA DATA VA NECESSARIAMENTE IN FORMATO gg/mm/aaaa
            Console.Write("Inserisci la data di nascita (gg/mm/aaaa): ");
            DateTime dataNascitaInput = DateTime.Parse(Console.ReadLine());
            DateOnly dataNascita = DateOnly.FromDateTime(dataNascitaInput);

            Console.Write("Inserisci il codice fiscale: ");
            string codiceFiscale = Console.ReadLine();

            //IL CICLO VIENE ESEGUITO FINO A CHE NON VIENE INSERITO UN PARAMETRO ADATTO.
            //ENUM.TRYPARSE TENTA LA CENVERSIONE DEL DATO INSERITO IN UNO DELL'ENUM
            //TRUE TOGLIE IL CASE-SENSITIVE RENDENDO m=M e f=F
            Sesso sesso;
            do
            {
                Console.Write("Inserisci il sesso (M/F): ");
            } 
            while (!Enum.TryParse(Console.ReadLine(), true, out sesso));

            Console.Write("Inserisci il comune di residenza: ");
            string comuneResidenza = Console.ReadLine();

            Console.Write("Inserisci il reddito annuale: ");
            decimal redditoAnnuale = decimal.Parse(Console.ReadLine());

            //CREO UNA NUOVA ISTANZA DI CONTRIBUENTE CON I DATI INSETIRI DALL'UTENTE
            Contribuente contribuente = new Contribuente(nome, cognome, dataNascita, codiceFiscale, sesso, comuneResidenza, redditoAnnuale);

            //SIMULO TEMPO DI ATTESA
            Console.WriteLine("-----------------------------");
            Console.WriteLine("CALCOLO DELL'IMPOSTA DA VERSARE:");
            
            //RICHIAMO IL METODO CHE STAMPA TUTTI I DETTAGLI E L'IMPOSTA CALCOLATA
            contribuente.StampaDettagli();
        }
    }
}
