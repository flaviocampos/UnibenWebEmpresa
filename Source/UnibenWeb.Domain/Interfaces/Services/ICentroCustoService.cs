using System;
using System.Collections.Generic;
using UnibenWeb.Domain.Entities;

namespace UnibenWeb.Domain.Interfaces.Services
{
    public interface ICentroCustoService : IDisposable
    {
        CentroCusto BuscaPorId(int id);
        IEnumerable<CentroCusto> BuscarTodos(int skip, int take);
        void VincularObjetoContexto(CentroCusto centroCusto);
    }
}
