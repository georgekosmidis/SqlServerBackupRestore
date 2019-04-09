using MsSqlBackupRestore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MsSqlBackupRestore.DbServices
{
    public class SqlServerBackup
    {
        private IDbConnectionFactory _dbConnection;
        private string SqlTemplate = "BACKUP DATABASE @db TO DISK = @bak;";
        public SqlServerBackup(IDbConnectionFactory dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void BackUp(string filePath)
        {
            using (var conn = _dbConnection.Get())
            {
                var command = new SqlCommand(SqlTemplate, (SqlConnection)conn);

                command.Parameters.AddWithValue("@db", conn.Database);
                command.Parameters.AddWithValue("@bak", filePath);
                command.CommandTimeout = 3600;

                conn.Open();

                command.ExecuteNonQuery();
            }
        }
    }
}
