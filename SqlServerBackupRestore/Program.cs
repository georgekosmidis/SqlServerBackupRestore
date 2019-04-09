using System;
using System.IO;
using System.Linq;
using MsSqlBackupRestore.Administration;
using MsSqlBackupRestore.DbServices;
using MsSqlBackupRestore.Interfaces;
using MsSqlBackupRestore.SqlServer;

namespace MsSqlBackupRestore
{
    class Program
    {
        static void Main(string[] args)
        {

            if (args.Count() == 0)
            {
                UI.PrintHelp();
                Console.ReadKey();
                return;
            }

            var arguments = new Arguments();
            arguments.ReadArguments(args);
            if (!arguments.CheckConfiguration((m) => Console.WriteLine(m)))
            {
                Console.WriteLine();
                Console.WriteLine();
                UI.PrintHelp();
                Console.ReadKey();
                return;
            }

            IDbConnectionFactory connectionFactory;
            if (String.IsNullOrWhiteSpace(arguments.Username))
                connectionFactory = new SqlServerConnectionFactory(arguments.Host, arguments.Db);
            else
                connectionFactory = new SqlServerConnectionFactory(arguments.Host, arguments.Username, arguments.Password, arguments.Db);

            if (arguments.BackUp)
            {
                new SqlServerBackup(connectionFactory)
                    .BackUp(arguments.BakFile);
            }

            if (arguments.Restore)
            {
                new SqlServerRestore(connectionFactory)
                    .Restore(arguments.BakFile);
                new SqlServerScript(connectionFactory)
                    .Execute(arguments.ScriptFile);
                if (arguments.DeleteFile)
                    File.Delete(arguments.BakFile);
            }

            Console.ReadKey();

        }
    }
}
