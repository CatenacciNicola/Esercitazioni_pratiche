using Esercitazione_17.Models;

using System.Collections.Generic;
using System.Data.SqlClient;

namespace Esercitazione_17.Data
{
    public class TrattamentoDao
    {
        private readonly string connectionString;

        public TrattamentoDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Trattamento> GetAllTrattamenti()
        {
            var trattamenti = new List<Trattamento>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Trattamenti";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var trattamento = new Trattamento
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Descrizione = reader.GetString(reader.GetOrdinal("Descrizione")),
                                TariffaSupplementare = reader.GetDecimal(reader.GetOrdinal("TariffaSupplementare"))
                            };

                            trattamenti.Add(trattamento);
                        }
                    }
                }
            }

            return trattamenti;
        }

        public Trattamento GetTrattamentoById(int id)
        {
            Trattamento trattamento = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Trattamenti WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            trattamento = new Trattamento
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Descrizione = reader.GetString(reader.GetOrdinal("Descrizione")),
                                TariffaSupplementare = reader.GetDecimal(reader.GetOrdinal("TariffaSupplementare"))
                            };
                        }
                    }
                }
            }

            return trattamento;
        }
    }
}
