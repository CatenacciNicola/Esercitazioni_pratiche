using Esercitazione_17.Models;

using System.Collections.Generic;
using System.Data.SqlClient;

namespace Esercitazione_17.Data
{
    public class CercaDao
    {
        private readonly string connectionString;

        public CercaDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Prenotazione> GetPrenotazioniByCodiceFiscale(string codiceFiscale)
        {
            var prenotazioni = new List<Prenotazione>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    SELECT p.*, c.Nome, c.Cognome, cam.Descrizione AS DescrizioneCamera, cam.Tipologia AS TipologiaCamera, t.Descrizione AS DescrizioneTrattamento
                    FROM Prenotazioni p
                    JOIN Clienti c ON p.CodiceFiscaleCliente = c.CodiceFiscale
                    JOIN Camere cam ON p.NumeroCamera = cam.Numero
                    JOIN Trattamenti t ON p.TrattamentoId = t.Id
                    WHERE p.CodiceFiscaleCliente = @CodiceFiscale";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CodiceFiscale", codiceFiscale);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var prenotazione = new Prenotazione
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                CodiceFiscaleCliente = reader.GetString(reader.GetOrdinal("CodiceFiscaleCliente")),
                                NomeCliente = reader.GetString(reader.GetOrdinal("Nome")),
                                CognomeCliente = reader.GetString(reader.GetOrdinal("Cognome")),
                                NumeroCamera = reader.GetInt32(reader.GetOrdinal("NumeroCamera")),
                                DescrizioneCamera = reader.GetString(reader.GetOrdinal("DescrizioneCamera")),
                                TipologiaCamera = reader.GetString(reader.GetOrdinal("TipologiaCamera")),
                                DescrizioneTrattamento = reader.GetString(reader.GetOrdinal("DescrizioneTrattamento")),
                                Dal = reader.GetDateTime(reader.GetOrdinal("Dal")),
                                Al = reader.GetDateTime(reader.GetOrdinal("Al")),
                                TariffaApplicata = reader.GetDecimal(reader.GetOrdinal("TariffaApplicata")),
                                CaparraConfirmatoria = reader.GetDecimal(reader.GetOrdinal("CaparraConfirmatoria")),
                                DataPrenotazione = reader.GetDateTime(reader.GetOrdinal("DataPrenotazione")),
                                NumeroProgressivoAnno = reader.GetInt32(reader.GetOrdinal("NumeroProgressivoAnno")),
                                Anno = reader.GetInt32(reader.GetOrdinal("Anno")),
                                TrattamentoId = reader.GetInt32(reader.GetOrdinal("TrattamentoId"))
                            };

                            prenotazioni.Add(prenotazione);
                        }
                    }
                }
            }

            return prenotazioni;
        }

        public int GetNumeroPrenotazioniPensioneCompleta()
        {
            int numeroPrenotazioni = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    SELECT COUNT(*)
                    FROM Prenotazioni p
                    JOIN Trattamenti t ON p.TrattamentoId = t.Id
                    WHERE t.Descrizione = 'Pensione Completa'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    numeroPrenotazioni = (int)cmd.ExecuteScalar();
                }
            }

            return numeroPrenotazioni;
        }
    }
}
