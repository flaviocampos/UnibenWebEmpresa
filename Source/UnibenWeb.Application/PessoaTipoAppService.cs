using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using UnibenWeb.Application.Interface;
using UnibenWeb.Application.ViewModels;
using UnibenWeb.Domain.Entities;

namespace UnibenWeb.Application
{
    public class PessoaTipoAppService:BaseAppService, IPessoaTipoAppService
    {

        private readonly IBaseAppService _baseService;


        public PessoaTipoAppService(IBaseAppService baseService)
        {
            _baseService = baseService;
        }

        public IEnumerable<PessoaTipoVM> BuscaComPesquisa(int offsetRows, int numRows, string pesquisa)
        {
            var pessoaTipos = _baseService.Pesquisar<PessoaTipo>(offsetRows, numRows, pesquisa, "PessoaTipos");
            return Mapper.Map<IEnumerable<PessoaTipo>, IEnumerable<PessoaTipoVM>>(pessoaTipos);
        }

        public void Dispose()
        {
            _baseService.Dispose();
        }

        public SelectList ListasDeSelecao()
        {
            var listaPessoaTipo = Pesquisar<PessoaTipoVM>(0, 999, "", "PessoaTipos");
            return new SelectList(listaPessoaTipo, "PessoaTipoId", "Descricao");
        }
    }
}