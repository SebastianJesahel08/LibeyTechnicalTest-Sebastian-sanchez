set -e

/opt/mssql/bin/sqlservr &

sleep 20

/var/opt/sqlserver/SqlCmdStartup.sh

wait
