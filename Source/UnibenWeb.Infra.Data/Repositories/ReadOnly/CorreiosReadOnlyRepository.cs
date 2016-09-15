using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.Interfaces.Repository.ReadOnly;

namespace UnibenWeb.Infra.Data.Repositories.ReadOnly
{
    public class CorreiosReadOnlyRepository: ICorreiosReadOnlyRepository

    {
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["CorreiosConnection"].ConnectionString);
            }
        }

        public Endereco BuscaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Endereco> BuscaComPesquisa(int offsetRows, int numRows, string pesquisaCondicao)
        {
            using (var cn = Connection)
            {
                cn.Open();
                const string sql = @"SELECT * FROM ac c
                    WHERE (@pPesquisa IS NULL OR cidade LIKE '%' + @pPesquisa + '%')
                    ORDER BY Cidade ASC
                    OFFSET @pOffset ROWS
                    FETCH NEXT @pRows ROWS ONLY";

                var endereco = cn.Query<Endereco>(sql, new { pPesquisa = pesquisaCondicao, pOffset = offsetRows, pRows = numRows });
                return endereco;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
