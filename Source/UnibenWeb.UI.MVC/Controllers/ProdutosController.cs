using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UnibenWeb.Application.Interface;
using UnibenWeb.Application.ViewModels;
using UnibenWeb.Infra.Data.Context;

namespace UnibenWeb.UI.MVC.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IBaseAppService _baseAppService;

        public ProdutosController(IBaseAppService baseAppService)
        {
            _baseAppService = baseAppService;
        }

        // GET: Produtos
        public ActionResult Index()
        {
            //return View(db.ProdutoVms.ToList());
            return View(_baseAppService.Pesquisar<ProdutoVm>(0,50,"","Produtos"));
        }
        /*
        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoVm produtoVm = db.ProdutoVms.Find(id);
            if (produtoVm == null)
            {
                return HttpNotFound();
            }
            return View(produtoVm);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutoId,NumeroRegistro,Sigla,DataRegistro,AtivoSituacao,PessoaId,SegmentoAssistencialId,TipoContratacaoProdutoId,AbrangenciaPlanoId,FatorModeradorId,AcomodacaoTipoId")] ProdutoVm produtoVm)
        {
            if (ModelState.IsValid)
            {
                db.ProdutoVms.Add(produtoVm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produtoVm);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoVm produtoVm = db.ProdutoVms.Find(id);
            if (produtoVm == null)
            {
                return HttpNotFound();
            }
            return View(produtoVm);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutoId,NumeroRegistro,Sigla,DataRegistro,AtivoSituacao,PessoaId,SegmentoAssistencialId,TipoContratacaoProdutoId,AbrangenciaPlanoId,FatorModeradorId,AcomodacaoTipoId")] ProdutoVm produtoVm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produtoVm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produtoVm);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoVm produtoVm = db.ProdutoVms.Find(id);
            if (produtoVm == null)
            {
                return HttpNotFound();
            }
            return View(produtoVm);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProdutoVm produtoVm = db.ProdutoVms.Find(id);
            db.ProdutoVms.Remove(produtoVm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        */
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // baseappservice dispose
            }
            base.Dispose(disposing);
        }
    }
}
