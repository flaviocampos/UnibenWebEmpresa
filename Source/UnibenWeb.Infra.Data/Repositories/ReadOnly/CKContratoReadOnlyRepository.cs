using System;
using System.Collections.Generic;
using Dapper;
using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.Interfaces.Repository.ReadOnly;

namespace UnibenWeb.Infra.Data.Repositories.ReadOnly
{
    public class CKContratoReadOnlyRepository : BaseReadOnlyRepository, ICKContratoReadOnlyRepository
    {
        public IEnumerable<CheckListContrato> BuscaTodos()
        {
            const string sql = @"SELECT * FROM CheckListContrato c";
            using (var cn = Connection)
            {
                cn.Open();
                var cKContrato = cn.Query<CheckListContrato>(sql);
                return cKContrato;
            }
        }

        public CheckListContrato BuscaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CheckListContrato> BuscaComPesquisa(int offset_rows, int num_rows, string pesquisa_condicao)
        {
            using (var cn = Connection)
            {
                cn.Open();
                var sql =
                    @"SELECT * FROM CheckListContrato c
                    WHERE (@pPesquisa IS NULL OR Nome LIKE '%' + @pPesquisa + '%')";
/*
                    ORDER BY Nome ASC
                    OFFSET @pOffset ROWS
                    FETCH NEXT @pRows ROWS ONLY";
                    */

                var cKContrato = cn.Query<CheckListContrato>(sql, new { pPesquisa = pesquisa_condicao, pOffset = offset_rows, pRows = num_rows });
                return cKContrato;
            }
        }

        public CheckListContrato BuscaComEnderecos(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}