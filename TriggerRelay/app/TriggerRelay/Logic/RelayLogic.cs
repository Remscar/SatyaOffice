using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TriggerRelay.Logic
{
    public class RelayLogic
    {
        public static RelayLogic instance;
        SqlConnection _sql;
        public RelayLogic()
        {
            _sql = new SqlConnection("Server=tcp:satya-db.database.windows.net,1433;Initial Catalog=satya-sql;MultipleActiveResultSets=true;Persist Security Info=False;User ID=satyadb;Password=MacroHard17;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            _sql.Open();
        }

        ~RelayLogic()
        {
            _sql.Close();
        }

        public void CheckConnection()
        {
            if (_sql.State == System.Data.ConnectionState.Closed || _sql.State == System.Data.ConnectionState.Broken)
            {
                _sql = new SqlConnection("Server=tcp:satya-db.database.windows.net,1433;Initial Catalog=satya-sql;Persist Security Info=False;User ID=satyadb;Password=MacroHard17;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                _sql.Open();
            }
        }

        public async void HandleTrigger(int userId)
        {
            CheckConnection();

            SqlCommand cmd = new SqlCommand($"INSERT INTO [dbo].[TriggerHistory] ([UserID]) VALUES ({userId})", _sql);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<string[]> GetTriggerList(int userId, int last)
        {
            CheckConnection();

            SqlCommand cmd = new SqlCommand("SELECT TOP 5 [EventID] FROM [dbo].[TriggerHistory] WHERE [EventID] > " +
                last + " AND [UserID] = " + userId + " ORDER BY [EventID] DESC", _sql);
            var dataReader = cmd.ExecuteReaderAsync().Result;

            List<string> results = new List<string>();
            

            while (dataReader.Read())
            {
                results.Add(dataReader.GetInt32(0).ToString());
            }

            return results.ToArray();
        }
    }
}
