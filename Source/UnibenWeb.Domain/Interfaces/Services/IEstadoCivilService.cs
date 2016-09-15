using System;
using System.Collections.Generic;
using UnibenWeb.Domain.Entities;

namespace UnibenWeb.Domain.Interfaces.Services
{
    public interface IEstadoCivilService : IDisposable
    {
        IEnumerable<EstadoCivil> BuscaTodos(int skip, int take);
    }
}