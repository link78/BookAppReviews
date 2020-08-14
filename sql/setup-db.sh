echo 'Please wait while sql server 2017 is running';

sleep 90s

echo 'Initializing db after 90 second';

/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P Marine7815@@ -d master -i sqlscript.sql
