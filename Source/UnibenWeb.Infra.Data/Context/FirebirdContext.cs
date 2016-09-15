using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnibenWeb.Infra.Data.Context
{
    public class FirebirdContext
    {
        public FbConnection[] ConnectionPool;

        const string connectionString = "User=SYSDBA;" + "Password=masterkey;" + "Database=D:\\Sistema\\info\\OPERADORAPS_old3.FDB;" +
                "DataSource=192.168.1.2;" + "Port=3050;" + "Dialect=3;" + "Charset=NONE;" + "Role=;" +
                "Connection lifetime=15;" + "Pooling=true;" + "MinPoolSize=0;" +
                "MaxPoolSize=50;" + "Packet Size=8192;" + "ServerType=0";

        public FirebirdContext()
        {
            if (ConnectionPool == null){
                ConnectionPool = new FbConnection[1];
            }
            if (ConnectionPool[0] == null)
            {
                ConnectionPool[0] = new FbConnection(connectionString);
            }
            if (ConnectionPool[0].State != System.Data.ConnectionState.Open)
            {
                ConnectionPool[0].Open();
            }
            
        }

        public FbConnection getConnection(int connectNumber)
        {
            return ConnectionPool[connectNumber];
        }

    }
}
