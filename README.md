
# MS SQL Backup & Restore
Simple helper to backup and restore sql server databases.

*Must run on the same machine the SQL Server resides, either for backing up or for delete*

## Usage
BackUp:
```
MsSqlBackupRestore -h data-source -db your-database [-u username] [-p password] -bk -bf path/to/bak-file
```
Restore:
```
MsSqlBackupRestore -h data-source -db your-database [-u username] [-p password] -r -bf path/to/bak-file [-c] [-ssf path/to/script-file]
```

## Options:

```
-h   : SQL server host
-u   : The database username (optional, omit to use Windows Authentication)
-p   : The database password (optional)
-db  : The database you want to back from or restore to
-bf  : The Backup file to either back up to or restore from. 
       Uses string interpolation for custom date-time format strings 
       (e.g. filename-{0:yyyy-MM-dd_hh-mm-ss-tt}.bak)
       Please read https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings
-ssf : Script to run against restored database (optional)
-c   : Delete backup file after restore (Valid only with -r switch)
-r   : Command signaling 'Restore' behaviour
-bk  : Command signaling 'Back up' behaviour
```
