using System.Collections.Generic;
using System.Data.SqlClient;
using ContravvenzioniWebApp.Models;
using Microsoft.Extensions.Configuration;

namespace ContravvenzioniWebApp.Data
{
    public class AnagraficaDAO
    {
        private readonly string _connectionString;

        public AnagraficaDAO(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Anagrafica> GetAll()
        {
            var anagrafiche = new List<Anagrafica>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT * FROM Anagrafica", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var anagrafica = new Anagrafica
                    {
                        IdAnagrafica = (int)reader["IdAnagrafica"],
                        Cognome = (string)reader["Cognome"],
                        Nome = (string)reader["Nome"],
                        Indirizzo = (string)reader["Indirizzo"],
                        Citta = (string)reader["Citta"],
                        Cap = (string)reader["Cap"],
                        CodFiscale = (string)reader["CodFiscale"]
                    };
                    anagrafiche.Add(anagrafica);
                }
            }

            return anagrafiche;
        }

        public void Add(Anagrafica anagrafica)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO Anagrafica (Cognome, Nome, Indirizzo, Citta, Cap, CodFiscale) VALUES (@Cognome, @Nome, @Indirizzo, @Citta, @Cap, @CodFiscale)", connection);
                command.Parameters.AddWithValue("@Cognome", anagrafica.Cognome);
                command.Parameters.AddWithValue("@Nome", anagrafica.Nome);
                command.Parameters.AddWithValue("@Indirizzo", anagrafica.Indirizzo);
                command.Parameters.AddWithValue("@Citta", anagrafica.Citta);
                command.Parameters.AddWithValue("@Cap", anagrafica.Cap);
                command.Parameters.AddWithValue("@CodFiscale", anagrafica.CodFiscale);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
