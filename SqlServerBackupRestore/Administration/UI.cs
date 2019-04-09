using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MsSqlBackupRestore.Administration
{
    public static class UI
    {
        public static void PrintHelp()
        {
            Console.WriteLine("***MS SQL Backup & Restore (http://github.com/georgekosmidis/mssql-schema-dump)***");
            Console.WriteLine("Helper to backup and restore sql server databasess");
            Console.WriteLine("BackUp:  MsSqlBackupRestore -h data-source-host -db your-database [-u username] [-p password]");
            Console.WriteLine("                            -bk -bf path/to/bak-file");
            Console.WriteLine("");
            Console.WriteLine("Restore: MsSqlBackupRestore -h data-source-host -db your-database [-u username] [-p password]");
            Console.WriteLine("                            -r -bf path/to/bak-file [-c] [-ssf path/to/script-file]");
            Console.WriteLine("");
            Console.WriteLine("Options:"); 
            Console.WriteLine("     -h   : SQL server host, defaults to (local)");
            Console.WriteLine("     -u   : username, defaults to sa");
            Console.WriteLine("     -p   : password, defaults to sa");
            Console.WriteLine("     -db  : The database you want to back from or restore to");
            Console.WriteLine("     -bf  : The Backup file to either back up to or restore from.");
            Console.WriteLine("     -ssf : Script to run against restored database");
            Console.WriteLine("     -c   : Delete backup file after restore");
            Console.WriteLine("     -r   : Command signaling 'Restore' behavior");
            Console.WriteLine("     -bk  : Command signaling 'Back up' behavior");
        }
    }
}
