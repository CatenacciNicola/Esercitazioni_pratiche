using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione_11
{
    //ENUMERAZIONE PER RAPPRESENTARE IL SESSO
    public enum Sesso
    {
        M,
        F
    }
    internal class Contribuente
    {
        //PROPRIETA' DEL CONTRIBUENTE
        public string Nome { get; private set; }
        public string Cognome { get; private set; }
        public DateOnly DataNascita { get; private set; }
        public string CodiceFiscale { get; private set; }
        public Sesso Sesso { get; private set; }
        public string ComuneResidenza { get; private set; }
        public decimal RedditoAnnuale { get; private set; }

        //COSTRUTTORE 
        public Contribuente(string nome, string cognome, DateOnly dataNascita, string codiceFiscale, Sesso sesso, string comuneResidenza, decimal redditoAnnuale)
        {
            Nome = nome;
            Cognome = cognome;
            DataNascita = dataNascita;
            CodiceFiscale = codiceFiscale;
            Sesso = sesso;
            ComuneResidenza = comuneResidenza;
            RedditoAnnuale = redditoAnnuale;
        }

        //METODO PER CALCOLARE L'IMPOSTA DATO IL REDDITO. VIENE ESEGUITO L'IF/ELSE IF IN BASE ALLA CIFRA INSERITA
        public decimal CalcolaImposta()
        {
            decimal imposta = 0;
            decimal reddito = RedditoAnnuale;

            if (reddito <= 15000)
            {
                imposta = reddito * 23 / 100;
            }
            else if (reddito <= 28000)
            {
                imposta = 3450 + ((reddito - 15000) * 27 / 100);
            }
            else if (reddito <= 55000)
            {
                imposta = 6960 + ((reddito - 28000) * 38 / 100);
            }
            else if (reddito <= 75000)
            {
                imposta = 17220 + ((reddito - 55000) * 41 / 100);
            }
            else
            {
                imposta = 25420 + ((reddito - 75000) * 43 / 100);
            }

            return imposta;
        }

        //METODO PER STAMPARE A VIDEO I DATI DEL CONTRIBUENTE E L'IMPOSTA CALCOLATA
        public void StampaDettagli()
        {
            Console.WriteLine($"Contribuente: {Nome} {Cognome}");
            Console.WriteLine($"Nato il: {DataNascita.ToString("dd/MM/yyyy")} ({Sesso})");
            Console.WriteLine($"Residente in: {ComuneResidenza}");
            Console.WriteLine($"Codice fiscale: {CodiceFiscale}");
            //SCRIVO EURO A PAROLE PERCHE' IL TERMINALE NON STAMPA IL SIMBOLO
            Console.WriteLine($"Reddito dichiarato: {RedditoAnnuale} euro");
            Console.WriteLine($"IMPOSTA DA VERSARE: {CalcolaImposta()} euro");
        }
    }
}
