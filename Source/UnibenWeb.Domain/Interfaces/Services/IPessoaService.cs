using System;
using System.Collections.Generic;
using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.ValueObjects;

namespace UnibenWeb.Domain.Interfaces.Services
{
    public interface IPessoaService: IDisposable
    {
        ValidationResult Adicionar(Pessoa pessoa);
        Pessoa BuscaPorId(int id);
        Pessoa BuscaPorCPF(string cpf);
        IEnumerable<Pessoa> BuscaTodos(int skip, int take);
        void Atualizar(Pessoa pessoa);
        void Remover(Pessoa pessoa);
    }
}
