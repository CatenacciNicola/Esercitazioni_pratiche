using System.Collections.Generic;
using System.Data.SqlClient;
using ContravvenzioniWebApp.Models;
using Microsoft.Extensions.Configuration;

namespace ContravvenzioniWebApp.Data
{
    public class ViolazioniAVerbaleDAO
    {
        private readonly string _connectionString;

        public ViolazioniAVerbaleDAO(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void Add(ViolazioniAVerbale violazioniAVerbale)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO ViolazioniAVerbale (IdVerbaleFK, IdViolazioneFK) VALUES (@IdVerbaleFK, @IdViolazioneFK)", connection);
                command.Parameters.AddWithValue("@IdVerbaleFK", violazioniAVerbale.IdVerbaleFK);
                command.Parameters.AddWithValue("@IdViolazioneFK", violazioniAVerbale.IdViolazioneFK);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
