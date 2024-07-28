using Esercitazione_17.Models;

using System.Collections.Generic;
using System.Data.SqlClient;

namespace Esercitazione_17.Data
{
    public class CameraDao
    {
        private readonly string connectionString;

        public CameraDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Camera> GetAllCamere()
        {
            var camere = new List<Camera>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Camere";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var camera = new Camera
                            {
                                Numero = reader.GetInt32(reader.GetOrdinal("Numero")),
                                Descrizione = reader.GetString(reader.GetOrdinal("Descrizione")),
                                Tipologia = reader.GetString(reader.GetOrdinal("Tipologia")),
                                TariffaBase = reader.GetDecimal(reader.GetOrdinal("TariffaBase"))
                            };

                            camere.Add(camera);
                        }
                    }
                }
            }

            return camere;
        }

        public Camera GetCameraByNumero(int numero)
        {
            Camera camera = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Camere WHERE Numero = @Numero";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Numero", numero);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            camera = new Camera
                            {
                                Numero = reader.GetInt32(reader.GetOrdinal("Numero")),
                                Descrizione = reader.GetString(reader.GetOrdinal("Descrizione")),
                                Tipologia = reader.GetString(reader.GetOrdinal("Tipologia")),
                                TariffaBase = reader.GetDecimal(reader.GetOrdinal("TariffaBase"))
                            };
                        }
                    }
                }
            }

            return camera;
        }
    }
}
