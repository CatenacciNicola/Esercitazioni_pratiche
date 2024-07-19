using System.Collections.Generic;
using System.Data.SqlClient;
using ContravvenzioniWebApp.Models;
using Microsoft.Extensions.Configuration;

namespace ContravvenzioniWebApp.Data
{
    public class VerbaleDAO
    {
        private readonly string _connectionString;

        public VerbaleDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        private SqlCommand GetCommand(string query, SqlConnection connection)
        {
            return new SqlCommand(query, connection);
        }

        public void Add(Verbale verbale)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO Verbale (DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, IdAnagraficaFK) VALUES (@DataViolazione, @IndirizzoViolazione, @NominativoAgente, @DataTrascrizioneVerbale, @Importo, @DecurtamentoPunti, @IdAnagraficaFK)", connection);
                command.Parameters.AddWithValue("@DataViolazione", verbale.DataViolazione);
                command.Parameters.AddWithValue("@IndirizzoViolazione", verbale.IndirizzoViolazione);
                command.Parameters.AddWithValue("@NominativoAgente", verbale.NominativoAgente);
                command.Parameters.AddWithValue("@DataTrascrizioneVerbale", verbale.DataTrascrizioneVerbale);
                command.Parameters.AddWithValue("@Importo", verbale.Importo);
                command.Parameters.AddWithValue("@DecurtamentoPunti", verbale.DecurtamentoPunti);
                command.Parameters.AddWithValue("@IdAnagraficaFK", verbale.IdAnagraficaFK);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public int GetLastInsertedId()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT TOP 1 IdVerbale FROM Verbale ORDER BY IdVerbale DESC", connection);
                connection.Open();
                return (int)command.ExecuteScalar();
            }
        }

        public IEnumerable<Verbale> GetVerbaliPerTrasgressore()
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = GetCommand("SELECT IdAnagraficaFK, COUNT(*) as TotaleVerbali FROM Verbale GROUP BY IdAnagraficaFK", conn);
            var list = new List<Verbale>();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Verbale
                {
                    IdAnagraficaFK = reader.GetInt32(0),
                    
                });
            }
            return list;
        }

        public IEnumerable<Verbale> GetPuntiDecurtatiPerTrasgressore()
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = GetCommand("SELECT IdAnagraficaFK, SUM(DecurtamentoPunti) as TotalePunti FROM Verbale GROUP BY IdAnagraficaFK", conn);
            var list = new List<Verbale>();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Verbale
                {
                    IdAnagraficaFK = reader.GetInt32(0),
                    DecurtamentoPunti = reader.GetInt32(1)
                    
                });
            }
            return list;
        }

        public IEnumerable<Verbale> GetVerbaliOltre10Punti()
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = GetCommand("SELECT V.Importo, A.Cognome, A.Nome, V.DataViolazione, V.DecurtamentoPunti FROM Verbale V JOIN Anagrafica A ON V.IdAnagraficaFK = A.IdAnagrafica WHERE V.DecurtamentoPunti > 10", conn);
            var list = new List<Verbale>();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Verbale
                {
                    Importo = reader.GetDecimal(0),
                    //Cognome = reader.GetString(1),
                    //Nome = reader.GetString(2),
                    DataViolazione = reader.GetDateTime(3),
                    DecurtamentoPunti = reader.GetInt32(4)
                    
                });
            }
            return list;
        }

        public IEnumerable<Verbale> GetVerbaliOltre400Euro()
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = GetCommand("SELECT * FROM Verbale WHERE Importo > 400", conn);
            var list = new List<Verbale>();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Verbale
                {
                    Importo = reader.GetDecimal(0),
                    
                });
            }
            return list;
        }

    }
}
