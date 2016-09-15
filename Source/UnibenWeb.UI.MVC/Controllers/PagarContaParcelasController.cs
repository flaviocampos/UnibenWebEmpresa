using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UnibenWeb.Application.Interface;
using UnibenWeb.Application.ViewModels;
using UnibenWeb.Infra.CrossCutting.MvcFilters;
using UnibenWeb.UI.MVC.Models;

namespace UnibenWeb.UI.MVC.Controllers
{
    public class PagarContaParcelasController : Controller
    {
        private readonly IBaseAppService _baseAppService;
        public PagarContaParcelasController(IBaseAppService baseAppService)
        {
            _baseAppService = baseAppService;
        }





        public ActionResult Criar()
        {
            return PartialView("_Criar");
        }
        [HttpPost, ValidateAntiForgeryToken, ValidateAjax]
        public ActionResult Criar(PagarContaParcelaVm pagarContaParcelaVm)
        {
            if (ModelState.IsValid)
            {
                /*
                var result = _pagarContaAppService.Adicionar(true, User.Identity.GetUserId(), pagarContaVm);
                if (!result.IsValid)
                {
                    foreach (var validationAppError in result.Erros)
                    {
                        ModelState.AddModelError(string.Empty, validationAppError.Message);
                    }

                    return Json(new { Resultado = result });
                }
                */
                return Json(new { Resultado = pagarContaParcelaVm.PagarContaParcelaId }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Validar = true });
            }
        }





        public ActionResult Detalhar(int id)
        {
            var pagarContaParcela = _baseAppService.Pesquisar<PagarContaParcelaVm>(0, 0, " PagarContaParcelaId = " + Convert.ToString(id), "PagarContaParcelas").FirstOrDefault();
            if (true /*Verifica se o Model é valido (DataAnnotations ou Regras de Negocio?), caso não seja, exibir os erros do modelo de dados.*/)
            {
                return PartialView("_Detalhar", pagarContaParcela);
            }
            else
            {
                return PartialView("_Detalhar", pagarContaParcela);
            }
        }





        public ActionResult Excluir(int id)
        {
            return PartialView("_Excluir", 222);
        }

        [HttpPost, ActionName("Excluir"), ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(int id)
        {
            var pagarContaParcelaVm = _baseAppService.Pesquisar<PagarContaParcelaVm>(0, 0, " PagarContaParcelaId = " + Convert.ToString(id), "PagarContaParcelas").FirstOrDefault();
            //_pagarContaAppService.Excluir(true, User.Identity.GetUserId(), pagarContaVm);
            return RedirectToAction("Listar");
        }





        public ActionResult Editar(int id)
        {
            var pagarContaParcelaVm = _baseAppService.Pesquisar<PagarContaParcelaVm>(0, 0, " PagarContaParcelaId = " + Convert.ToString(id), "PagarContaParcelas").FirstOrDefault();
            //ViewBag.CentroCustos = _baseAppService.ListasDeSelecao<CentroCustoVm>("CentroCustoId", "Descricao", "CentroCustos", "");
            //pagarContaVm.CentroCustoId = pagarContaVm.CentrosCusto.Select(x => x.CentroCustoId).ToArray();
            return PartialView("_Editar", pagarContaParcelaVm);
        }
        [HttpPost, ValidateAntiForgeryToken, ValidateAjax]
        public ActionResult Editar(PagarContaParcelaVm pagarContaParcelaVm)
        {
            if (ModelState.IsValid)
            {
                //_pagarContaAppService.Atualizar(true, User.Identity.GetUserId(), pagarContaVm);
                return Json(new { Resultado = pagarContaParcelaVm.PagarContaParcelaId }, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Listar");
            }
            //ViewBag.CentroCustos = _baseAppService.ListasDeSelecao<CentroCustoVm>("CentroCustoId", "Descricao", "CentroCustos", "");
            //pagarContaVm.CentroCustoId = pagarContaVm.CentrosCusto.Select(x => x.CentroCustoId).ToArray();
            return Json(new { Validar = true });
        }





        public ActionResult Listar(int id)
        {
            ViewBag.pagarContaId = id;
            return View();
        }





        public ActionResult FillDataTables_AjaxHandler(JQueryDataTableParamModel param, int? id)
        {
            var contNumResult = _baseAppService.Pesquisar<int>("PagarContas", 0, "", 0, "", " count(*) as NumRegistros ", "1").FirstOrDefault();
            //IEnumerable<PagarContaParcelaVm> filteredResults;
            var calculatedParams = param.GetCalculatedParams(Request.QueryString);

            var filteredResults = _baseAppService.Pesquisar<PagarContaParcelaVm>(
    "PagarContaParcelas",
    param.iDisplayStart,
    "", //" join [dbo].[ContaPagarCentroCusto] tb2 on tb2.ContaPagarId = tb.PagarContaId join [dbo].[CentroCustos] tb3 on tb3.CentroCustoId = tb2.CentroCustoId ",
    param.iDisplayLength,
    calculatedParams.ToArray()[0] + calculatedParams.ToArray()[1],
    " tb.* ", // , tb3.Descricao as CentrosCustoDescricao
    calculatedParams.ToArray()[2]);

            var result = from c in filteredResults
                         select new[] {
                Convert.ToString(c.PagarContaParcelaId),
                Convert.ToString(c.DataPagamento),
                Convert.ToString(c.DataVencimento),
                Convert.ToString(c.Desconto),
                Convert.ToString(c.Descricao),
                Convert.ToString(c.Juros),
                Convert.ToString(c.Observacao),
                Convert.ToString(c.Status),
                Convert.ToString(c.ValorParcela)};

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = contNumResult.ToString(),
                iTotalDisplayRecords = filteredResults.Count(),
                aaData = result
            }, JsonRequestBehavior.AllowGet);

            /*

            if (!string.IsNullOrEmpty(param.sSearch))
            {
                var Col_01_Filter = Convert.ToString(Request["sSearch_1"]);
                var Col_02_Filter = Convert.ToString(Request["sSearch_2"]);
                var Col_03_Filter = Convert.ToString(Request["sSearch_3"]);
                var isCol_01_Searchable = Convert.ToBoolean(Request["bSearchable_1"]);
                var isCol_02_Searchable = Convert.ToBoolean(Request["bSearchable_2"]);
                var isCol_03_Searchable = Convert.ToBoolean(Request["bSearchable_3"]);
                filteredContas = _baseAppService.Pesquisar<PagarContaParcelaVm>(0, 999, " contaOrigemId = " + id, "PagarContaParcelas")
                   .Where(c => isCol_01_Searchable && (Convert.ToString(c.Descricao)).ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isCol_02_Searchable && (Convert.ToString(c.Observacao)).ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isCol_03_Searchable && (Convert.ToString(c.DataVencimento)).ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isCol_03_Searchable && (Convert.ToString(c.DataPagamento)).ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isCol_03_Searchable && (Convert.ToString(c.ValorParcela)).ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isCol_03_Searchable && (Convert.ToString(c.Juros)).ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isCol_03_Searchable && (Convert.ToString(c.Desconto)).ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isCol_03_Searchable && (Convert.ToString(c.Status)).ToLower().Contains(param.sSearch.ToLower())
                               );
            }
            else
            {
                filteredContas = _baseAppService.Pesquisar<PagarContaParcelaVm>(0, 999, " contaOrigemId = " + id, "PagarContaParcelas"); ;
            }
            var isCol_01_Sortable = Convert.ToBoolean(Request["bSortable_1"]);
            var isCol_02_Sortable = Convert.ToBoolean(Request["bSortable_2"]);
            var isCol_03_Sortable = Convert.ToBoolean(Request["bSortable_3"]);
            var isCol_04_Sortable = Convert.ToBoolean(Request["bSortable_4"]);
            var isCol_05_Sortable = Convert.ToBoolean(Request["bSortable_5"]);
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<PagarContaParcelaVm, string> orderingFunction = (c => sortColumnIndex == 1 && isCol_01_Sortable ? Convert.ToString(c.Descricao) :
                                                           sortColumnIndex == 2 && isCol_02_Sortable ? Convert.ToString(c.Observacao) :
                                                           sortColumnIndex == 3 && isCol_03_Sortable ? Convert.ToString(c.DataVencimento) :
                                                           sortColumnIndex == 4 && isCol_04_Sortable ? Convert.ToString(c.DataPagamento) :
                                                           sortColumnIndex == 5 && isCol_05_Sortable ? Convert.ToString(c.ValorParcela) :
                                                           sortColumnIndex == 5 && isCol_05_Sortable ? Convert.ToString(c.Juros) :
                                                           sortColumnIndex == 6 && isCol_05_Sortable ? Convert.ToString(c.Desconto) :
                                                           sortColumnIndex == 7 && isCol_05_Sortable ? Convert.ToString(c.Status) :
                                                           "");
            var sortDirection = Request["sSortDir_0"];
            if (sortDirection == "asc")
                filteredContas = filteredContas.OrderBy(orderingFunction);
            else
                filteredContas = filteredContas.OrderByDescending(orderingFunction);
            var displayedContas = filteredContas.Skip(param.iDisplayStart).Take(param.iDisplayLength);
            var result = from c in displayedContas
                         select new[] {
                Convert.ToString(c.PagarContaParcelaId),
                Convert.ToString(c.Descricao),
                Convert.ToString(c.Observacao),
                Convert.ToString(c.DataVencimento),
                Convert.ToString(c.DataPagamento),
                Convert.ToString(c.Juros),
                Convert.ToString(c.Desconto),
                Convert.ToString(c.ValorParcela),
                Convert.ToString(c.Status)
                         };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = filteredContas.Count(),
                iTotalDisplayRecords = filteredContas.Count(),
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }
        */
        }
    }
}