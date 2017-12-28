using ControleEstoque.Models;
using ControleEstoque.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleEstoque.Controllers
{
    public class DevedorController : Controller
    {
            private ApplicationDbContext _context;

            public DevedorController()
            {
                  _context = new ApplicationDbContext();
            }

            public ActionResult Devedor()
            {
                  var devedores = _context.Devedores.ToList();
                  return View(devedores);
            }

            public ActionResult Index()
            {
                  return View();
            }

            public ActionResult Detalhe(int id)
            {
                  var devedores = _context.Devedores.ToList();
                  return View(devedores.Find(devedor => devedor.Id == id));
            }

            //CRUD start here:

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Save(Devedor devedor)
            {
                  if (!ModelState.IsValid)
                  {
                        var viewModel = new DevedorFormViewModel
                        {
                              Devedor = devedor
                        };
                        return View("FormDevedor", viewModel);
                  }

                  if (devedor.Id == 0)
                  {
                        _context.Devedores.Add(devedor);
                  }
                  else
                  {
                        var devedorInDb = _context.Devedores.Single(c => c.Id == devedor.Id);

                        devedorInDb.Cliente = devedor.Cliente;
                        devedorInDb.Id = devedor.Id;
                        devedorInDb.Observacoes = devedor.Observacoes;
                  }

                  // faz a persistência
                  _context.SaveChanges();
                  // Voltamos para a lista de devedores
                  return RedirectToAction("Devedor");
            }


            public ActionResult Edit(int id)
            {

                  var devedor = this._context.Devedores.SingleOrDefault(m => m.Id == id);

                  if (devedor == null)
                        return HttpNotFound();



                  var devedorViewModel = new DevedorFormViewModel()
                  {
                        Devedor = devedor
                  };


                  return View("FormDevedor", devedorViewModel);
            }

            public ActionResult New()
            {

                  var devedorViewModel = new DevedorFormViewModel
                  {
                        Devedor = new Devedor()
                  };

                  return View("FormDevedor", devedorViewModel);

            }
            [HttpPost]
            public ActionResult Delete(int id)
            {
                  var devedor = this._context.Devedores.Find(id);

                  if (devedor != null)
                  {

                        this._context.Devedores.Remove(devedor);
                        this._context.SaveChanges();

                  }

                  return RedirectToAction("Devedor");


            }



            protected override void Dispose(bool disposing)
            {
                  _context.Dispose();
            }
      }
}