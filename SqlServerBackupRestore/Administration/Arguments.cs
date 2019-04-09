using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MsSqlBackupRestore.Administration
{
    public class Arguments
    {
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Db { get; set; }
        public string BakFile { get; set; }
        public string ScriptFile { get; set; }
        public bool DeleteFile { get; set; } = false;
        public bool Restore { get; set; } = false;
        public bool BackUp { get; set; } = false;

        public void ReadArguments(string[] args)
        {
            for (int i = 0; i < args.Count(); i++)
            {
                switch (args[i])
                {
                    case "-h":
                        Host = args[i + 1];
                        i++;
                        continue;
                    case "-u":
                        Username = args[i + 1];
                        i++;
                        continue;
                    case "-p":
                        Password = args[i + 1];
                        i++;
                        continue;
                    case "-db":
                        Db = args[i + 1];
                        continue;
                    case "-bf":
                        BakFile = String.Format(args[i + 1], DateTime.Now);
                        i++;
                        continue;
                    case "-ssf":
                        ScriptFile = args[i + 1];
                        i++;
                        continue;
                    case "-c":
                        DeleteFile = true;
                        continue;
                    case "-r":
                        Restore = true;
                        continue;
                    case "-bk":
                        BackUp = true;
                        continue;
                }
            }
        }

        public bool CheckConfiguration(Action<string> ui)
        {
            if (!String.IsNullOrWhiteSpace(ScriptFile))
            {
                if (!File.Exists(ScriptFile))
                {
                    ui("There is no scramble script file '" + ScriptFile + "' !");
                    return false;
                }
            }
            if(BackUp && Restore)
            {
                ui("What is the point of Backing up and Restoring at the same time?");
                return false;
            }
            if (!BackUp && !Restore)
            {
                ui("You need to at least backup(-bk) or restore(-r)!");
                return false;
            }

            if (String.IsNullOrWhiteSpace(Host) || String.IsNullOrWhiteSpace(Db))
            {
                ui("You have to at lease setup Host(-h) and Database(-db)!");
                return false;
            }
            if (BackUp)
            {
                if (File.Exists(BakFile))
                {
                    ui("There is already a file '"+ BakFile + "' !");
                    return false;
                }
                if (DeleteFile)
                {
                    ui("What is the point of Backing up and then immediatly deleting?");
                    return false;
                }
            }
            if (Restore)
            {
                if (!File.Exists(BakFile))
                {
                    ui("There is no back up file '" + BakFile + "' !");
                    return false;
                }
            }
            return true;
        }
    }
}
