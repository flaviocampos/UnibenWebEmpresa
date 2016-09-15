using System;
using System.Collections.Generic;
using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.ValueObjects;

namespace UnibenWeb.Domain.Interfaces.Services
{
    public interface IEnderecoService : IDisposable
    {
        Endereco BuscaPorId(int id);
        ValidationResult Adicionar(Endereco endereco);
        IEnumerable<Endereco> BuscaComPesquisa(int offsetRows, int numRows, string pesquisaCondicao);
        IEnumerable<Endereco> BuscaComPesquisa(int offsetRows, int numRows, string pesquisaCondicao, int pessoaId);
    }
}