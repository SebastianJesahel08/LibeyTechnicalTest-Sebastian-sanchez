/opt/mssql/bin/sqlservr &
sleep 60
/opt/mssql-tools/bin/sqlcmd \
-S localhost \
-U sa \
-P "SqlServer@123" \
-d master \
-i /var/opt/sqlserver/SqlCmdScript.sql
wait
