echo 'Starting the Database'

# Run Microsoft SQl Server and initialization script (at the same time)
/usr/src/app/setup-db.sh & /opt/mssql/bin/sqlservr