using Esercitazione_17.Models;

using System.Collections.Generic;
using System.Data.SqlClient;

namespace Esercitazione_17.Data
{
    public class ClienteDao
    {
        private readonly string connectionString;

        public ClienteDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Cliente> GetAllClienti()
        {
            var clienti = new List<Cliente>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Clienti";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cliente = new Cliente
                            {
                                CodiceFiscale = reader.GetString(reader.GetOrdinal("CodiceFiscale")),
                                Cognome = reader.GetString(reader.GetOrdinal("Cognome")),
                                Nome = reader.GetString(reader.GetOrdinal("Nome")),
                                Citta = reader.GetString(reader.GetOrdinal("Citta")),
                                Provincia = reader.GetString(reader.GetOrdinal("Provincia")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                Telefono = reader.GetString(reader.GetOrdinal("Telefono")),
                                Cellulare = reader.GetString(reader.GetOrdinal("Cellulare"))
                            };

                            clienti.Add(cliente);
                        }
                    }
                }
            }

            return clienti;
        }

        public void AddCliente(Cliente cliente)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Clienti (CodiceFiscale, Cognome, Nome, Citta, Provincia, Email, Telefono, Cellulare) VALUES (@CodiceFiscale, @Cognome, @Nome, @Citta, @Provincia, @Email, @Telefono, @Cellulare)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CodiceFiscale", cliente.CodiceFiscale);
                    cmd.Parameters.AddWithValue("@Cognome", cliente.Cognome);
                    cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@Citta", cliente.Citta);
                    cmd.Parameters.AddWithValue("@Provincia", cliente.Provincia);
                    cmd.Parameters.AddWithValue("@Email", cliente.Email);
                    cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue("@Cellulare", cliente.Cellulare);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
