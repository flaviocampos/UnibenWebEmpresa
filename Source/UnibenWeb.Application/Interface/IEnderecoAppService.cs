using System;
using System.Collections.Generic;
using UnibenWeb.Application.Validation;
using UnibenWeb.Application.ViewModels;

namespace UnibenWeb.Application.Interface
{
    public interface IEnderecoAppService : IDisposable
    {
        EnderecoVM BuscaPorId(int id);
        ValidationAppResult Adicionar(bool doLog, string userId, EnderecoVM endereco);
        IEnumerable<EnderecoVM> BuscaComPesquisa(int offsetRows, int numRows, string pesquisaCondicao);
        IEnumerable<EnderecoVM> BuscaComPesquisa(int offsetRows, int numRows, string pesquisaCondicao, int pessoaId);
    }
}