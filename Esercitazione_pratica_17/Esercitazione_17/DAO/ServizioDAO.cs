using Esercitazione_17.Models;

using System.Collections.Generic;
using System.Data.SqlClient;

namespace Esercitazione_17.Data
{
    public class ServizioDao
    {
        private readonly string connectionString;

        public ServizioDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Servizio> GetAllServizi()
        {
            var servizi = new List<Servizio>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Servizi";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var servizio = new Servizio
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Descrizione = reader.GetString(reader.GetOrdinal("Descrizione")),
                                Prezzo = reader.GetDecimal(reader.GetOrdinal("Prezzo"))
                            };

                            servizi.Add(servizio);
                        }
                    }
                }
            }

            return servizi;
        }

        public Servizio GetServizioById(int id)
        {
            Servizio servizio = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Servizi WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            servizio = new Servizio
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Descrizione = reader.GetString(reader.GetOrdinal("Descrizione")),
                                Prezzo = reader.GetDecimal(reader.GetOrdinal("Prezzo"))
                            };
                        }
                    }
                }
            }

            return servizio;
        }

    }
}
