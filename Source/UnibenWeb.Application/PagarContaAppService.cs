using System;
using AutoMapper;
using UnibenWeb.Application.Interface;
using UnibenWeb.Application.Validation;
using UnibenWeb.Application.ViewModels;
using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace UnibenWeb.Application
{
    public class PagarContaAppService : BaseAppService, IPagarContaAppService
    {
        private readonly IPagarContaService _pagarContaService;
        private readonly IBaseService _baseService;
        private readonly ICentroCustoService _centroCustoService;

        public PagarContaAppService(IPagarContaService pagarContaService, IBaseService baseService, ICentroCustoService centroCustoService)
        {
            _pagarContaService = pagarContaService;
            _baseService = baseService;
            _centroCustoService = centroCustoService;
        
        }

        public ValidationAppResult Adicionar(bool doLog, string userId, PagarContaVm pagarContaVm)
        {
            var pagarConta = Mapper.Map<PagarContaVm, PagarConta>(pagarContaVm);
            pagarConta.CentrosCusto = new List<CentroCusto>();
            var commaDelimitedListOfCentrosCusto = string.Join(",", (IList < int >)pagarContaVm.CentroCustoId).ToString();
            var centrosCustoVm = _baseService.Pesquisar<CentroCustoVm>(0, 0, " CentroCustoId in (" + commaDelimitedListOfCentrosCusto + ")", "CentroCustos");

            pagarConta.DataNegociacao = null;
            pagarConta.ContaPagarNegociacaoId = null;

            foreach (var _centroCustoVm in centrosCustoVm)
            {
                var centroCusto = Mapper.Map<CentroCustoVm, CentroCusto>(_centroCustoVm);
                _centroCustoService.VincularObjetoContexto(centroCusto);
                pagarConta.CentrosCusto.Add(centroCusto);
            }

            var auxValor = pagarConta.ValorTotal;
            var auxVencimentos = DateTime.Now;
            pagarConta.ContaParcelas = new List<PagarContaParcela>();

            for (int i = 0; i < pagarConta.NumeroParcelas; i++)
            {
                auxVencimentos = auxVencimentos.AddMonths(1);
                var novaParcela = new PagarContaParcela { ValorParcela = (pagarConta.ValorTotal / pagarConta.NumeroParcelas), ContaOrigem = pagarConta, DataPagamento = null, DataVencimento = auxVencimentos, Desconto = 0, Juros = 0, Descricao = "", Observacao = "", Status = false};
                pagarConta.ContaParcelas.Add(novaParcela);
            }

            BeginTransaction();
            var result =  _pagarContaService.Adicionar(pagarConta);
            if (!result.IsValid) { return DomainToApllicationResult(result); }
            Commit(doLog, userId);
            pagarContaVm.PagarContaId = pagarConta.PagarContaId;
            return DomainToApllicationResult(result);
        }

        public void Excluir(bool doLog, string userId, PagarContaVm pagarContaVm)
        {
            var pagarConta = Mapper.Map<PagarContaVm, PagarConta>(pagarContaVm);
            BeginTransaction();
            _pagarContaService.Excluir(pagarConta);
            Commit(doLog, userId);
        }

        public void Atualizar(bool doLog, string userId, PagarContaVm pagarContaVm)
        {
            //var pagarConta = Mapper.Map<PagarContaVm, PagarConta>(pagarContaVm);
            var pagarConta = _pagarContaService.BuscarPorId("CentrosCusto", pagarContaVm.PagarContaId);
            pagarConta.DataNegociacao = null;
            pagarConta.ContaPagarNegociacaoId = null;
            pagarConta.Descricao = pagarContaVm.Descricao;
            pagarConta.NumeroParcelas = pagarContaVm.NumeroParcelas;
            pagarConta.Observacao = pagarContaVm.Observacao;
            pagarConta.Status = pagarContaVm.Status;
            pagarConta.ValorTotal = pagarContaVm.ValorTotal;
            pagarConta.DataPrevisaoPagamento = pagarContaVm.DataPrevisaoPagamento;
            pagarConta.DataEmissao = pagarContaVm.DataEmissao;
            pagarConta.DataAcolhimentoContaPagar = pagarContaVm.DataAcolhimentoContaPagar;
            pagarConta.ContaTipoDocumentoId = pagarContaVm.ContaTipoDocumentoId;
            pagarConta.TipoLancamentoId = pagarContaVm.TipoLancamentoId;
            var toadd = pagarContaVm.CentroCustoId.Except(pagarConta.CentrosCusto.Select(y => y.CentroCustoId));
            var todelete = pagarConta.CentrosCusto.Where(x => !pagarContaVm.CentroCustoId.Contains(x.CentroCustoId));
            foreach (var _item in toadd)
            {
                var _centroCusto = _centroCustoService.BuscaPorId(_item);
                _centroCustoService.VincularObjetoContexto(_centroCusto);
                pagarConta.CentrosCusto.Add(_centroCusto);
            }
            foreach (var _item in todelete.ToList())
            {
                _centroCustoService.VincularObjetoContexto(_item);
                pagarConta.CentrosCusto.Remove(_item);
            }
            // http://www.entityframeworktutorial.net/EntityFramework4.3/update-many-to-many-entity-using-dbcontext.aspx
            // http://www.codeproject.com/Tips/893609/CRUD-Many-to-Many-Entity-Framework
            //pagarConta.CentrosCusto = new List<CentroCusto>();
            //var commaDelimitedListOfCentrosCusto = string.Join(",", (IList<int>)pagarContaVm.CentroCustoId).ToString();
            //var centrosCustoVm = (IList<CentroCustoVm>)_baseService.Pesquisar<CentroCustoVm>(0, 0, " CentroCustoId in (" + commaDelimitedListOfCentrosCusto + ")", "CentroCustos");
            //foreach (var _centroCustoVm in centrosCustoVm)
            // {
            //    var centroCusto = Mapper.Map<CentroCustoVm, CentroCusto>(_centroCustoVm);
            //    _centroCustoService.VincularObjetoContexto(centroCusto);
            //    pagarConta.CentrosCusto.Add(centroCusto);
            //pagarConta.CentrosCusto.Remove(_centroCustoService.BuscaPorId(1));
            //}
            //foreach (var _item in pagarConta.CentrosCusto)
            //{
            //    _centroCustoService.VincularObjetoContexto(_item);
            // }
            //foreach (var item in todelete)
            //{
            // var delCentroCusto = Mapper.Map<CentroCustoVm, CentroCusto>(item);
            //   pagarConta.CentrosCusto.Remove(item);
            //}
            /*
            foreach (var _centroCustoVm in centrosCustoVm) // compara as listagens
            {
                //var matches = oldPagarContaVm.CentrosCusto.Where(x=>x.CentroCustoId == _centroCustoVm.CentroCustoId);

                if (!oldPagarContaVm.CentrosCusto.Contains(_centroCustoVm))
                {
                    // nao contem
                    var centroCusto = Mapper.Map<CentroCustoVm, CentroCusto>(_centroCustoVm);
                    pagarConta.CentrosCusto.Add(centroCusto);
                } else
                {
                    // contem
                }
            }
            foreach (var _centroCustoVm in centrosCustoVm)
            {
                var centroCusto = Mapper.Map<CentroCustoVm, CentroCusto>(_centroCustoVm);
                pagarConta.CentrosCusto.Add(centroCusto);

                //pagarConta.CentrosCusto.Add(_centroCustoService.BuscaPorId(1));
            }
            */
            ///foreach (var obj in pagarConta.CentrosCusto)
            //{
            //    _centroCustoService.VincularObjetoContexto(obj);
            //}
            BeginTransaction();
            _pagarContaService.Atualizar(pagarConta);
            Commit(doLog, userId);
        }

        public PagarContaVm BuscarPorId(int id)
        {
            var pagarConta = _pagarContaService.BuscarPorId(id);
            return Mapper.Map<PagarConta, PagarContaVm>(pagarConta);
        }
    }
}
