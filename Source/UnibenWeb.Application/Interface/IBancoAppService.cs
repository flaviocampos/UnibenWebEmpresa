using System;
using System.Collections.Generic;
using UnibenWeb.Application.ViewModels;
using Banco = UnibenWeb.Domain.Entities.Banco;
using System.Web.Mvc;

namespace UnibenWeb.Application.Interface
{
    public interface IBancoAppService:IDisposable
    {
        IEnumerable<BancoVM> BuscaComPesquisa(int skip, int take, string pesquisa);
        IEnumerable<Banco> RetornaLista(int skip, int take, string pesquisa);
        string BoletoImprimir(); // List<BoletoBancario> boletos
        SelectList ListasDeSelecao();
    }
}
