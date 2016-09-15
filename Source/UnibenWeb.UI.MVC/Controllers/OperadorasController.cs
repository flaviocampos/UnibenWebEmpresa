using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using UnibenWeb.Application.Interface;
using UnibenWeb.Application.ViewModels;
using UnibenWeb.Infra.CrossCutting.MvcFilters;

namespace UnibenWeb.UI.MVC.Controllers
{
    [RoutePrefix("Cadastro/Operadoras")]
    [Route("{action=ListarOperadoras}")]
    //[Route("{idpessoa:int?}/Pessoa/Detalhe/{iddetalhe:int?}")]
    public class OperadorasController : Controller
    {
        private readonly IBaseAppService _baseAppService;
        private readonly IPessoaAppService _pessoaAppService;

        public OperadorasController(
            IPessoaAppService pessoaAppService,
            IBaseAppService baseAppService)
        {
            _pessoaAppService = pessoaAppService;
            _baseAppService = baseAppService;
        }

        public ActionResult ListarOperadoras()
        {
            return View(_baseAppService.Pesquisar<OperadoraVm>(0,50," PessoaTipoId = 2 ","Pessoas"));
        }

        public ActionResult CriarOperadora()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAjax]
        public ActionResult CriarOperadora( /* [Bind(Include = "PessoaId,Nome,CPF,DataNascimento,DataCadastro,Ativo")] */
            OperadoraVm operadoraVm)
        {
            if (ModelState.IsValid)
            {
                var result = _pessoaAppService.Adicionar(true, User.Identity.GetUserId(), operadoraVm);
                if (!result.IsValid)
                {

                
                    /*
                    var result = _pessoaAppService.Adicionar(true, User.Identity.GetUserId(), pessoaEnderecoVM);
                    if (!result.IsValid)
                    {
                        foreach (var validationAppError in result.Erros)
                        {
                            ModelState.AddModelError(string.Empty, validationAppError.Message);
                        }

                        var selList = _bancoAppService.BuscaComPesquisa(0, 999, null);
                        ViewBag.Bancos = new SelectList(selList, "BancoId", "Nome");

                        var listaEstadoCivis = _estadoCivilAppService.BuscaTodos(0, 999);
                        ViewBag.EstadoCivis = new SelectList(listaEstadoCivis, "EstadoCivilId", "descricao");

                        var listaPessoaTipo = _baseAppService.Pesquisar<PessoaTipoVM>(0, 10, "", "PessoaTipos");
                        ViewBag.PessoaTipos = new SelectList(listaPessoaTipo, "PessoaTipoId", "Descricao");

                        //return Json(new { Resultado = result });
                        // return View(pessoaEnderecoVM);
                        return View();
                    }
                    */
                    // return RedirectToAction("Index");
                    // return Json(new { Resultado = pessoaEnderecoVM.PessoaId }, JsonRequestBehavior.AllowGet);
                    return View();
                }
            }
            else
            {
                /*
                var selList = _bancoAppService.BuscaComPesquisa(0, 999, null);
                ViewBag.Bancos = new SelectList(selList, "BancoId", "Nome");

                var listaEstadoCivis = _estadoCivilAppService.BuscaTodos(0, 999);
                ViewBag.EstadoCivis = new SelectList(listaEstadoCivis, "EstadoCivilId", "descricao");

                var listaPessoaTipo = _baseAppService.Pesquisar<PessoaTipoVM>(0, 10, "", "PessoaTipos");
                ViewBag.PessoaTipos = new SelectList(listaPessoaTipo, "PessoaTipoId", "Descricao");
                */

            }
            //return Json(new { Validar = true });
            return View();
        }

    }
}