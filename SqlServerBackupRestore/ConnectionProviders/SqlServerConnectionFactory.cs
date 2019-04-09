using MsSqlBackupRestore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MsSqlBackupRestore.SqlServer
{
    public class SqlServerConnectionFactory : IDbConnectionFactory
    {
        private string _server;
        private string _username;
        private string _password;
        private string _db;
        public SqlServerConnectionFactory(string server, string username, string password, string db)
        {
            _server = server;
            _username = username;
            _password = password;
            _db = db;
        }
        public SqlServerConnectionFactory(string server, string db)
        {
            _server = server;
            _db = db;
        }

        public IDbConnection Get()
        {
            var conn = new SqlConnection();
            if (_username == null)
                conn.ConnectionString = "Data Source=" + _server + ";Initial Catalog=" + _db + ";Integrated Security=SSPI;";
            else
                conn.ConnectionString = "Data Source=" + _server + ";Initial Catalog=" + _db + ";User id=" + _username + ";Password=" + _password + ";";
            return conn;
        }

    }

}
