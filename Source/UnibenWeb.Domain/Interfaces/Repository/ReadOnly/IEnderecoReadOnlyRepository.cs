using System.Collections.Generic;
using UnibenWeb.Domain.Entities;

namespace UnibenWeb.Domain.Interfaces.Repository.ReadOnly
{
    public interface IEnderecoReadOnlyRepository
    {
        IEnumerable<Endereco> BuscaComPesquisa(int offsetRows, int numRows, string pesquisaCondicao, int pessoaId);
    }
}