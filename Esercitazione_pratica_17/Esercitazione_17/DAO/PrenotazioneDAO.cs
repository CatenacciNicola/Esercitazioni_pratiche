using Esercitazione_17.Models;

using System.Data.SqlClient;

namespace Esercitazione_17.Data
{
    public class PrenotazioneDao
    {
        private readonly string connectionString;

        public PrenotazioneDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddPrenotazione(SalvaPrenotazione prenotazione)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Prenotazioni (CodiceFiscaleCliente, NumeroCamera, DataPrenotazione, NumeroProgressivoAnno, Anno, Dal, Al, CaparraConfirmatoria, TariffaApplicata, TrattamentoId) " +
                             "VALUES (@CodiceFiscaleCliente, @NumeroCamera, @DataPrenotazione, @NumeroProgressivoAnno, @Anno, @Dal, @Al, @CaparraConfirmatoria, @TariffaApplicata, @TrattamentoId)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CodiceFiscaleCliente", prenotazione.CodiceFiscaleCliente);
                    cmd.Parameters.AddWithValue("@NumeroCamera", prenotazione.NumeroCamera);
                    cmd.Parameters.AddWithValue("@DataPrenotazione", prenotazione.DataPrenotazione);
                    cmd.Parameters.AddWithValue("@NumeroProgressivoAnno", prenotazione.NumeroProgressivoAnno);
                    cmd.Parameters.AddWithValue("@Anno", prenotazione.Anno);
                    cmd.Parameters.AddWithValue("@Dal", prenotazione.Dal);
                    cmd.Parameters.AddWithValue("@Al", prenotazione.Al);
                    cmd.Parameters.AddWithValue("@CaparraConfirmatoria", prenotazione.CaparraConfirmatoria);
                    cmd.Parameters.AddWithValue("@TariffaApplicata", prenotazione.TariffaApplicata);
                    cmd.Parameters.AddWithValue("@TrattamentoId", prenotazione.TrattamentoId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<Prenotazione> GetAllPrenotazioni()
        {
            var prenotazioni = new List<Prenotazione>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT p.*, c.Nome, c.Cognome " +
                             "FROM Prenotazioni p " +
                             "JOIN Clienti c ON p.CodiceFiscaleCliente = c.CodiceFiscale";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
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
                                Dal = reader.GetDateTime(reader.GetOrdinal("Dal")),
                                Al = reader.GetDateTime(reader.GetOrdinal("Al")),
                                
                            };

                            prenotazioni.Add(prenotazione);
                        }
                    }
                }
            }

            return prenotazioni;
        }

        public Prenotazione GetPrenotazioneById(int id)
        {
            Prenotazione prenotazione = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = @"
                    SELECT p.*, c.Nome, c.Cognome, cam.Descrizione AS DescrizioneCamera, cam.Tipologia AS TipologiaCamera, t.Descrizione AS DescrizioneTrattamento
                    FROM Prenotazioni p
                    JOIN Clienti c ON p.CodiceFiscaleCliente = c.CodiceFiscale
                    JOIN Camere cam ON p.NumeroCamera = cam.Numero
                    JOIN Trattamenti t ON p.TrattamentoId = t.Id
                    WHERE p.Id = @Id";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            prenotazione = new Prenotazione
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                CodiceFiscaleCliente = reader.GetString(reader.GetOrdinal("CodiceFiscaleCliente")),
                                NomeCliente = reader.GetString(reader.GetOrdinal("Nome")),
                                CognomeCliente = reader.GetString(reader.GetOrdinal("Cognome")),
                                NumeroCamera = reader.GetInt32(reader.GetOrdinal("NumeroCamera")),
                                Dal = reader.GetDateTime(reader.GetOrdinal("Dal")),
                                Al = reader.GetDateTime(reader.GetOrdinal("Al")),
                                TariffaApplicata = reader.GetDecimal(reader.GetOrdinal("TariffaApplicata")),
                                CaparraConfirmatoria = reader.GetDecimal(reader.GetOrdinal("CaparraConfirmatoria")),
                                DescrizioneCamera = reader.GetString(reader.GetOrdinal("DescrizioneCamera")),
                                TipologiaCamera = reader.GetString(reader.GetOrdinal("TipologiaCamera")),
                                DescrizioneTrattamento = reader.GetString(reader.GetOrdinal("DescrizioneTrattamento")),


                            };
                        }
                    }
                }
            }

            return prenotazione;
        }
    }
}
