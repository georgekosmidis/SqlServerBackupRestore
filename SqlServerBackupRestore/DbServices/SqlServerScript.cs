using MsSqlBackupRestore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace MsSqlBackupRestore.DbServices
{
    public class SqlServerScript
    {
        private IDbConnectionFactory _dbConnection;

        public SqlServerScript(IDbConnectionFactory dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void Execute(string filePath)
        {
            using (var conn = _dbConnection.Get())
            {
                var sql = File.ReadAllText(filePath);
                var command = new SqlCommand(sql, (SqlConnection)conn);
                command.CommandTimeout = 60;
                conn.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
