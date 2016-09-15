using System;
using System.Collections.Generic;
using System.Web.Mvc;
using UnibenWeb.Application.ViewModels;

namespace UnibenWeb.Application.Interface
{
    public interface IPessoaTipoAppService: IDisposable
    {
        IEnumerable<PessoaTipoVM> BuscaComPesquisa(int offsetRows, int numRows,string pesquisa);
        SelectList ListasDeSelecao();
    }
}