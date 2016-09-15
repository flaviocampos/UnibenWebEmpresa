using System.Collections.Generic;
using UnibenWeb.Domain.Entities;

namespace UnibenWeb.Domain.Interfaces.Repository.ReadOnly
{
    public interface IBancoReadOnlyRepository
    {
        IEnumerable<Banco> BuscaComPesquisa(int offsetRows, int numRows, string pesquisaCondicao);
    }
}
