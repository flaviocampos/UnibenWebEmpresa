using System;
using System.Collections.Generic;
using System.Web.Mvc;
using UnibenWeb.Application.ViewModels;

namespace UnibenWeb.Application.Interface
{
    public interface IEstadoCivilAppService : IDisposable
    {
        IEnumerable<EstadoCivilVM> BuscaTodos(int skip, int take);
        SelectList ListasDeSelecao();
    }
}