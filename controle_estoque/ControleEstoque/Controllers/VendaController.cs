using ControleEstoque.Models;
using ControleEstoque.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleEstoque.Controllers
{
      [Authorize]
    public class VendaController : Controller
    {
            private ApplicationDbContext _context;

            public VendaController()
            {
                  _context = new ApplicationDbContext();
            }

            public ActionResult Venda()
            {
                  var vendas = _context.Vendas.ToList();
                  return View(vendas);
            }

            public ActionResult Index()
            {
                  return View();
            }

            public ActionResult Detalhe(int id)
            {
                  var vendas = _context.Vendas.ToList();
                  return View(vendas.Find(venda => venda.Id == id));
            }

            //CRUD start here:

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Save(Venda venda)
            {
                  if (!ModelState.IsValid)
                  {
                        var viewModel = new VendaFormViewModel
                        {
                              Venda = venda
                        };
                        return View("FormVenda", viewModel);
                  }

                  if (venda.Id == 0)
                  {
                        _context.Vendas.Add(venda);
                  }
                  else
                  {
                        var vendaInDb = _context.Vendas.Single(c => c.Id == venda.Id);

                        vendaInDb.Valor = venda.Valor;
                        vendaInDb.Data = venda.Data;
                  }

                  // faz a persistência
                  _context.SaveChanges();
                  // Voltamos para a lista de vendas
                  return RedirectToAction("Venda");
            }


            public ActionResult Edit(int id)
            {

                  var venda = this._context.Vendas.SingleOrDefault(m => m.Id == id);

                  if (venda == null)
                        return HttpNotFound();



                  var vendaViewModel = new VendaFormViewModel()
                  {
                        Venda = venda
                  };


                  return View("FormVenda", vendaViewModel);
            }

            public ActionResult New()
            {

                  var vendaViewModel = new VendaFormViewModel
                  {
                        Venda = new Venda()
                  };

                  return View("FormVenda", vendaViewModel);

            }
            [HttpPost]
            public ActionResult Delete(int id)
            {
                  var venda = this._context.Vendas.Find(id);

                  if (venda != null)
                  {

                        this._context.Vendas.Remove(venda);
                        this._context.SaveChanges();

                  }

                  return RedirectToAction("Venda");


            }



            protected override void Dispose(bool disposing)
            {
                  _context.Dispose();
            }
      }
}