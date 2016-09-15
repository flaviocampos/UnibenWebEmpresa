using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using UnibenWeb.Domain.Interfaces.Repository;
using UnibenWeb.Infra.Data.Context;
using UnibenWeb.Infra.Data.Interfaces;
using System.Data.Common;
using FirebirdSql.Data.FirebirdClient;

namespace UnibenWeb.Infra.Data.Repositories
{
    public class BaseFbRepository : IBaseFbRepository
    {
        private readonly ContextManager _contextManager = ServiceLocator.Current.GetInstance<IContextManager>() as ContextManager;
        protected readonly FirebirdContext FbContext = new FirebirdContext();

        public BaseFbRepository()
        {
            FbContext = _contextManager.GetFbContext();
        }

        public List<DbDataRecord> FbQuery(string sql)
        {
            var cnn = FbContext.getConnection(0);
            FbTransaction tran = cnn.BeginTransaction();
            FbCommand fbCmd = new FbCommand();
            fbCmd.CommandText = sql;
            // myCommand.CommandText ="UPDATE TEST_TABLE_01 SET CLOB_FIELD = @CLOB_FIELD WHERE INT_FIELD = @INT_FIELD";
            fbCmd.Connection = cnn;
            fbCmd.Transaction = tran;
            //myCommand.Parameters.Add("@INT_FIELD", FbType.Integer, "INT_FIELD");
            // myCommand.Parameters.Add("@CLOB_FIELD", FbType.Text, "CLOB_FIELD");
            //myCommand.Parameters[0].Value = 1;
            //myCommand.Parameters[1].Value = GetFileContents(@"GDS.CS");
            // Execute

            var result = fbCmd.ExecuteReader();
            var rows = new List<DbDataRecord>();
            foreach (var record in result)
            {
                var values = ((DbDataRecord) record);
                rows.Add(values);
                // Console.WriteLine(values["clicodigo"] + " / " + values["clinome"]);
            }

            /*
            using (var reader = fbCmd.ExecuteReader())
                {
                var rows = new List<object[]>();
                while (reader.Read())
                    {
                        var columns = new object[reader.FieldCount];
                        reader.GetValues(columns);
                        rows.Add(columns);
                    }
                    return rows;
                }
                */

            /*
            foreach (var item in result)
            {
                var values = ((DbDataRecord)item);
                Console.WriteLine(values["clicodigo"] + " / " + values["clinome"]);
            }
            */
            // Commit changes
            tran.Commit();
            // Free command resources in Firebird Server
            tran.Dispose();
            // Close connection
            //cnn.Close();

            return rows; // DbDataRecord in FbDataReader
        }
    }
}
