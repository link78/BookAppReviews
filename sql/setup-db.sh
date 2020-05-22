echo 'PLease wait while sql server is running'

sleep 10s

echo 'Initializing sql server after 10 second'

/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P Marine7815@@ -d master -i sqlscript.sh