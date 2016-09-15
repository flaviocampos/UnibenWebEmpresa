using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UnibenWeb.Application;
using UnibenWeb.Application.Interface;
using UnibenWeb.Application.ViewModels;

namespace UnibenWeb.Services.WebAPI.Controllers
{
    public class PessoasController : ApiController
    {
        //private readonly PessoaAppService _pessoaAppService = new PessoaAppService();
        private readonly IPessoaAppService _pessoaAppService;

        public PessoasController(IPessoaAppService pessoaAppService)
        {
            _pessoaAppService = pessoaAppService;
        }

        // www.asp.net/web-api/overview

        [HttpGet]
        // GET: api/Pessoas
        public IEnumerable<PessoaVM> ObterTodos()
        {
            //return new string[] { "value1", "value2" };
            return _pessoaAppService.BuscaTodos(0,50);
        }

        // GET: api/Pessoas/5
        public PessoaVM Get(int id)
        {
            return _pessoaAppService.BuscaPorId(id);
        }

        // POST: api/Pessoas
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Pessoas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pessoas/5
        public void Delete(int id)
        {
        }
    }
}
