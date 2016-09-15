using System;
using System.Collections.Generic;
using UnibenWeb.Domain.Entities;

namespace UnibenWeb.Domain.Interfaces.Services
{
    public interface IBancoService : IDisposable
    {
        void Adicionar(Banco banco);
        Banco BuscaPorId(int id);
        IEnumerable<Banco> BuscaTodos(int skip, int take);
        void Atualizar(Banco banco);
        void Remover(Banco banco);
    }
}