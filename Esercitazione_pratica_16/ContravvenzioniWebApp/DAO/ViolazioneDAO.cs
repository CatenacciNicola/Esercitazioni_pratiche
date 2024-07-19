using System.Collections.Generic;
using System.Data.SqlClient;
using ContravvenzioniWebApp.Models;
using Microsoft.Extensions.Configuration;

namespace ContravvenzioniWebApp.Data
{
    public class ViolazioneDAO
    {
        private readonly string _connectionString;

        public ViolazioneDAO(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Violazione> GetAll()
        {
            var violazioni = new List<Violazione>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Violazione", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var violazione = new Violazione
                    {
                        IdViolazione = (int)reader["IdViolazione"],
                        Descrizione = (string)reader["Descrizione"]
                    };
                    violazioni.Add(violazione);
                }
            }

            return violazioni;
        }

        public void Add(Violazione violazione)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO Violazione (Descrizione) VALUES (@Descrizione)", connection);
                command.Parameters.AddWithValue("@Descrizione", violazione.Descrizione);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
