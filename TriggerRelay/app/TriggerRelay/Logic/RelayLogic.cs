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
        SqlConnection _sql;
        public RelayLogic()
        {
            _sql = new SqlConnection("Server=tcp:satya-db.database.windows.net,1433;Initial Catalog=satya-sql;Persist Security Info=False;User ID=satyadb;Password=MacroHard17;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            _sql.Open();
        }
        public void HandleTrigger(int userId)
        {
            SqlCommand cmd = new SqlCommand($"INSERT INTO [dbo].[TriggerHistory] ([UserID]) VALUES ({userId})", _sql);
            cmd.ExecuteNonQuery();
        }
    }
}
