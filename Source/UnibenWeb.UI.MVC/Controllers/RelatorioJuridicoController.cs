using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnibenWeb.Application.Interface;
using UnibenWeb.UI.MVC.Models;

namespace UnibenWeb.UI.MVC.Controllers
{
    [RoutePrefix("Juridico")]
    [Route("{action=Relatorio}")]
    public class RelatorioJuridicoController : Controller
    {
        private readonly IBaseFbAppService _baseFbAppService;
        public RelatorioJuridicoController(IBaseFbAppService baseFbAppService)
        {
            _baseFbAppService = baseFbAppService;
        }
        // GET: RelatorioJuridico
        public ActionResult Relatorio()
        {
            //var teste = _baseFbAppService.Query("SELECT * FROM CLIENTE");
            return View();
        }

        public ActionResult FillDataTables_AjaxHandler(JQueryDataTableParamModel param)
        {
            var cont = _baseFbAppService.Query("SELECT COUNT(*) FROM CLIENTE"); ; // select count from consulta (total de registros)
            //IEnumerable<ContaPagarComCentroCustoVm> filteredContas;
            //Check whether the companies should be filtered by keyword
            var calculatedParams = param.GetCalculatedParams(Request.QueryString).ToArray();
            var auxSelect = "tb.*";
            var whereClause = "";
            if (!String.IsNullOrEmpty(calculatedParams[0] + calculatedParams[1]))
            {
               whereClause += " WHERE " + calculatedParams[0] + calculatedParams[1];
            }
            var sql = "SELECT  * FROM CLIENTE tb " + whereClause + " ORDER BY " + calculatedParams[2]; // FIRST " + param.iDisplayLength.ToString() + " SKIP " + param.iDisplayStart.ToString() + "
            var tableData = _baseFbAppService.Query(sql); // registros com filtro

            var displayData = tableData.Skip(param.iDisplayStart).Take(param.iDisplayLength);

            var result = from c in displayData // displayedContas 
                         select new[] { Convert.ToString(c[0]), Convert.ToString(c[1]), Convert.ToString(c[2]), Convert.ToString(c[3]), Convert.ToString(c[4]), Convert.ToString(c[5]), Convert.ToString(c[6]) };


            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = cont[0][0].ToString(),
                iTotalDisplayRecords = tableData.Count(),
                aaData = result
            }, JsonRequestBehavior.AllowGet);
        }


    }
}