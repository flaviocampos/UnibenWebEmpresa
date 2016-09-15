using System;
using Dapper;
using System.Collections.Generic;
using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.Interfaces.Repository.ReadOnly;
using System.Linq;

namespace UnibenWeb.Infra.Data.Repositories.ReadOnly
{
    public class PessoaReadOnlyRepository : BaseReadOnlyRepository, IPessoaReadOnlyRepository
    {
        public Pessoa BuscaComEnderecos(Guid id)
        {
            const string sql =
                @"SELECT * FROM Pessoas P
                INNER JOIN PessoaEndereco PE on PE.pessoaId = P.pessoaId
                INNER JOIN Enderecos E on E.enderecoId = PE.enderecoId
                WHERE P.pessoaId = @sid";

            using (var cn = Connection)
            {
                cn.Open();
                var pessoa = cn.Query<Pessoa, Endereco, Pessoa>(sql,
                        (p, e) =>
                        {
                            p.Enderecos.Add(e);
                            return p;
                        }, new { sid = id }, splitOn:"pessoaId, enderecoId"
                    );
                return pessoa.FirstOrDefault();
            }
        }

        public IEnumerable<Pessoa> BuscaComPesquisa(int offset_rows, int num_rows, string pesquisa_condicao)
        {
            using (var cn = Connection)
            {
                cn.Open();
                var sql = 
                  @"SELECT * FROM Pessoas c
                    WHERE (@pPesquisa IS NULL OR Nome LIKE '%' + @pPesquisa + '%')
                    ORDER BY Nome ASC
                    OFFSET @pOffset ROWS
                    FETCH NEXT @pRows ROWS ONLY";

                var pessoa = cn.Query<Pessoa>(sql, new { pPesquisa = pesquisa_condicao, pOffset = offset_rows, pRows = num_rows });
                return pessoa;
            }
        }

        public Pessoa BuscaPorCPF(string cpf)
        {
            throw new NotImplementedException();
        }

        public Pessoa BuscaPorId(int id)
        {
            using (var cn = Connection)
            {
                //throw new Exception("Erro ao Buscar por ID");
                cn.Open();
                var sql =
                  @"SELECT * FROM Pessoas c
                    WHERE (@pID = pessoaId)";

                var pessoa = cn.Query<Pessoa>(sql, new { pID = id });
                return pessoa.FirstOrDefault();
            }
        }

        public IEnumerable<Pessoa> BuscaTodos()
        {
            const string sql = @"select * from Pessoas c";

            using (var cn = Connection)
            {
                cn.Open();
                var pessoa = cn.Query<Pessoa>(sql);
                return pessoa;
            }
        }
    }
}
