using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.Interfaces.Repository.ReadOnly;

namespace UnibenWeb.Infra.Data.Repositories.ReadOnly
{
    public class BancoReadOnlyRepository : BaseReadOnlyRepository, IBancoReadOnlyRepository
    {
        public IEnumerable<Banco> BuscaComPesquisa(int offsetRows, int numRows, string pesquisaCondicao)
        {
            using (var cn = Connection)
            {
                cn.Open();
                /*
                var sql =
                  @"SELECT * FROM Pessoas c
                    WHERE (@pPesquisa IS NULL OR Nome LIKE '%' + @pPesquisa + '%')
                    ORDER BY Nome ASC
                    OFFSET @pOffset ROWS
                    FETCH NEXT @pRows ROWS ONLY";
                    */
                var sql = @"SELECT * FROM Bancos c";

                var banco = cn.Query<Banco>(sql, new { pPesquisa = pesquisaCondicao, pOffset = offsetRows, pRows = numRows });
                return banco;
            }
        }
    }
}
