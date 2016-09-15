using System.Collections.Generic;
using Dapper;
using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.Interfaces.Repository.ReadOnly;

namespace UnibenWeb.Infra.Data.Repositories.ReadOnly
{
    public class EnderecoReadOnlyRepository : BaseReadOnlyRepository, IEnderecoReadOnlyRepository
    {
        public IEnumerable<Endereco> BuscaComPesquisa(int offsetRows, int numRows, string pesquisaCondicao, int pessoaId)
        {
            using (var cn = Connection)
            {
                cn.Open();
                var sql =
                  @"SELECT * FROM Enderecos c
                    WHERE (@pPesquisa IS NULL OR c.pessoaId = @pPesquisa)
                    ORDER BY c.CEP ASC
                    OFFSET @pOffset ROWS
                    FETCH NEXT @pRows ROWS ONLY";
                //WHERE (@pPesquisa IS NULL OR logradouro LIKE '%' + @pPesquisa + '%')

                var endereco = cn.Query<Endereco>(sql, new { pPesquisa = pessoaId, pOffset = offsetRows, pRows = numRows });
                return endereco;
            }
        }
    }
}