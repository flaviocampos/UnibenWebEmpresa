using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using UnibenWeb.Application.Interface;
using UnibenWeb.Application.ViewModels;

namespace UnibenWeb.UI.MVC.Controllers
{
    public class EnderecosController : Controller
    {
        private readonly IEnderecoAppService _enderecoAppService;

        public EnderecosController(IEnderecoAppService enderecoAppService)
        {
            _enderecoAppService = enderecoAppService;
        }

        // GET: Enderecos/...
        public ActionResult ListarEnderecos(int id)
        {
            var lista = _enderecoAppService.BuscaComPesquisa(0, 9999, null, id);
            ViewBag.Pessoa = id;
            return PartialView("_ListarEnderecos", lista);
        }

        public ActionResult SalvarEndereco(string logradouro, string numero, string cep, string bairro, string complemento, int idPessoa)
        {
            
            var end = new EnderecoVM() { CEP = cep, Bairro = bairro, Logradouro = logradouro, Complemento = complemento, Numero = numero, PessoaId = idPessoa };
            _enderecoAppService.Adicionar(true, User.Identity.GetUserId(),end);
            return Json(new { Resultado = end.PessoaId}, JsonRequestBehavior.AllowGet);

        }

    }
}