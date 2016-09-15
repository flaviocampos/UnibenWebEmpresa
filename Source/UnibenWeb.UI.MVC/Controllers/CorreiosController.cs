using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UnibenWeb.Application.Interface;
using UnibenWeb.Application.ViewModels;
using UnibenWeb.UI.MVC.Models;

namespace UnibenWeb.UI.MVC.Controllers
{
    public class CorreiosController : Controller
    {
        private readonly IEnderecoAppService _enderecoAppService;

        public CorreiosController(IEnderecoAppService enderecoAppService)
        {
            _enderecoAppService = enderecoAppService;
        }

        public ActionResult Index()
        {
            return View(); 
        }

        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            var enderecos = _enderecoAppService.BuscaComPesquisa(0, 9999, null);
            IEnumerable<EnderecoVM> enderecosFiltered;
            //Check whether the companies should be filtered by keyword
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                //Used if particulare columns are filtered 
                var nameFilter = Convert.ToString(Request["sSearch_1"]);
                var addressFilter = Convert.ToString(Request["sSearch_2"]);
                var townFilter = Convert.ToString(Request["sSearch_3"]);

                //Optionally check whether the columns are searchable at all 
                var isNameSearchable = Convert.ToBoolean(Request["bSearchable_1"]);
                var isAddressSearchable = Convert.ToBoolean(Request["bSearchable_2"]);
                var isTownSearchable = Convert.ToBoolean(Request["bSearchable_3"]);

                enderecosFiltered = _enderecoAppService.BuscaComPesquisa(0, 9999,null)
                   .Where(c => isNameSearchable && c.CEP.ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isAddressSearchable && c.Bairro.ToLower().Contains(param.sSearch.ToLower())
                               ||
                               isTownSearchable && c.Logradouro.ToLower().Contains(param.sSearch.ToLower()));
            }
            else
            {
                enderecosFiltered = enderecos;
            }

            var isNameSortable = Convert.ToBoolean(Request["bSortable_1"]);
            var isAddressSortable = Convert.ToBoolean(Request["bSortable_2"]);
            var isTownSortable = Convert.ToBoolean(Request["bSortable_3"]);
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<EnderecoVM, string> orderingFunction = (c => sortColumnIndex == 1 && isNameSortable ? c.CEP :
                                                           sortColumnIndex == 2 && isAddressSortable ? c.Bairro :
                                                           sortColumnIndex == 3 && isTownSortable ? c.Logradouro :
                                                           "");

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            if (sortDirection == "asc")
                enderecosFiltered = enderecosFiltered.OrderBy(orderingFunction);
            else
                enderecosFiltered = enderecosFiltered.OrderByDescending(orderingFunction);

            var displayedCompanies = enderecosFiltered.Skip(param.iDisplayStart).Take(param.iDisplayLength);
            var result = from c in displayedCompanies select new[] { Convert.ToString(c.EnderecoId), c.CEP, c.Bairro, c.Logradouro };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = enderecos.Count(),
                iTotalDisplayRecords = enderecosFiltered.Count(),
                aaData = result
            },
                        JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _enderecoAppService.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
