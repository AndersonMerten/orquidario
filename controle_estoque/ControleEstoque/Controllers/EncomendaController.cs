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
    public class EncomendaController : Controller
    {

            private ApplicationDbContext _context;

            public EncomendaController()
            {
                  _context = new ApplicationDbContext();
            }

            public ActionResult Encomenda()
            {
                  var encomendas = _context.Encomendas.ToList();
                  return View(encomendas);
            }

            public ActionResult Index()
            {
                  return View();
            }

            public ActionResult Detalhe(int id)
            {
                  var encomendas = _context.Encomendas.ToList();
                  return View(encomendas.Find(encomenda => encomenda.Id == id));
            }

            //CRUD start here:

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Save(Encomenda encomenda)
            {
                  if (!ModelState.IsValid)
                  {
                        var viewModel = new EncomendaFormViewModel
                        {
                              Encomenda = encomenda
                        };
                        return View("FormEncomenda", viewModel);
                  }

                  if (encomenda.Id == 0)
                  {
                        _context.Encomendas.Add(encomenda);
                  }
                  else
                  {
                        var encomendaInDb = _context.Encomendas.Single(c => c.Id == encomenda.Id);

                        encomendaInDb.Cliente = encomenda.Cliente;
                        encomendaInDb.Produto = encomenda.Produto;
                        encomendaInDb.Id = encomenda.Id;
                        encomendaInDb.Contato = encomenda.Contato;
                        encomendaInDb.Foto = encomenda.Foto;
                        encomendaInDb.Valor = encomenda.Valor;
                  }

                  // faz a persistência
                  _context.SaveChanges();
                  // Voltamos para a lista de encomendas
                  return RedirectToAction("Encomenda");
            }


            public ActionResult Edit(int id)
            {

                  var encomenda = this._context.Encomendas.SingleOrDefault(m => m.Id == id);

                  if (encomenda == null)
                        return HttpNotFound();



                  var encomendaViewModel = new EncomendaFormViewModel()
                  {
                        Encomenda = encomenda
                  };


                  return View("FormEncomenda", encomendaViewModel);
            }

            public ActionResult New()
            {

                  var encomendaViewModel = new EncomendaFormViewModel
                  {
                        Encomenda = new Encomenda()
                  };

                  return View("FormEncomenda", encomendaViewModel);

            }
            [HttpPost]
            public ActionResult Delete(int id)
            {
                  var encomenda = this._context.Encomendas.Find(id);

                  if (encomenda != null)
                  {

                        this._context.Encomendas.Remove(encomenda);
                        this._context.SaveChanges();

                  }

                  return RedirectToAction("Encomenda");


            }



            protected override void Dispose(bool disposing)
            {
                  _context.Dispose();
            }
      }
}