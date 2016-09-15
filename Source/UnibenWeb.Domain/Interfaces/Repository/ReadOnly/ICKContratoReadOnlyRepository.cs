using System;
using System.Collections.Generic;
using UnibenWeb.Domain.Entities;

namespace UnibenWeb.Domain.Interfaces.Repository.ReadOnly
{
    public interface ICKContratoReadOnlyRepository
    {
        IEnumerable<CheckListContrato> BuscaTodos();
        CheckListContrato BuscaPorId(int id);
        IEnumerable<CheckListContrato> BuscaComPesquisa(int offset_rows, int num_rows, string pesquisa_condicao);
        CheckListContrato BuscaComEnderecos(Guid id);
    }
}