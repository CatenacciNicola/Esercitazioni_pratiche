using Esercitazione_17.Models;

using System.Collections.Generic;
using System.Data.SqlClient;

namespace Esercitazione_17.Data
{
    public class PrenotazioneServizioDao
    {
        private readonly string connectionString;

        public PrenotazioneServizioDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<PrenotazioneServizio> GetServiziByPrenotazioneId(int prenotazioneId)
        {
            var serviziPrenotazione = new List<PrenotazioneServizio>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT ps.*, s.Descrizione " +
                             "FROM Prenotazioni_Servizi ps " +
                             "JOIN Servizi s ON ps.IdServizio = s.Id " +
                             "WHERE ps.IdPrenotazione = @IdPrenotazione";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IdPrenotazione", prenotazioneId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var prenotazioneServizio = new PrenotazioneServizio
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                IdPrenotazione = reader.GetInt32(reader.GetOrdinal("IdPrenotazione")),
                                IdServizio = reader.GetInt32(reader.GetOrdinal("IdServizio")),
                                Data = reader.GetDateTime(reader.GetOrdinal("Data")),
                                Quantita = reader.GetInt32(reader.GetOrdinal("Quantita")),
                                Prezzo = reader.GetDecimal(reader.GetOrdinal("Prezzo")),
                                DescrizioneServizio = reader.GetString(reader.GetOrdinal("Descrizione"))
                            };

                            serviziPrenotazione.Add(prenotazioneServizio);
                        }
                    }
                }
            }

            return serviziPrenotazione;
        }
        public void AddServizioPrenotazione(PrenotazioneServizio prenotazioneServizio)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Prenotazioni_Servizi (IdPrenotazione, IdServizio, Data, Quantita, Prezzo) " +
                             "VALUES (@IdPrenotazione, @IdServizio, @Data, @Quantita, @Prezzo)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@IdPrenotazione", prenotazioneServizio.IdPrenotazione);
                    cmd.Parameters.AddWithValue("@IdServizio", prenotazioneServizio.IdServizio);
                    cmd.Parameters.AddWithValue("@Data", prenotazioneServizio.Data);
                    cmd.Parameters.AddWithValue("@Quantita", prenotazioneServizio.Quantita);
                    cmd.Parameters.AddWithValue("@Prezzo", prenotazioneServizio.Prezzo);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
