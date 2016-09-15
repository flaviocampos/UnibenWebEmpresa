using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnibenWeb.Domain.Entities;

namespace UnibenWeb.Domain.Interfaces.Repository.ReadOnly
{
    public interface ICorreiosReadOnlyRepository: IDisposable
    {
        /*
        IEnumerable<Pessoa> BuscaTodos();
        Pessoa BuscaPorId(int id);
        Pessoa BuscaPorCPF(string cpf);
        IEnumerable<Pessoa> BuscaComPesquisa(int offset_rows, int num_rows, string pesquisa_condicao);
        Pessoa BuscaComEnderecos(Guid id);
        */
        Endereco BuscaPorId(int id);
        IEnumerable<Endereco> BuscaComPesquisa(int offsetRows, int numRows, string pesquisaCondicao);
    }
}
