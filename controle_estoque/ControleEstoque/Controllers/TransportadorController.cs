using ControleEstoque.Models;
using ControleEstoque.ViewModels;
using System.Data.Entity;
using System.Linq;

using System.Web.Mvc;

namespace ControleEstoque.Controllers
{
      [Authorize]
      public class TransportadorController : Controller
    {
           
            private ApplicationDbContext _context;

            public TransportadorController()
            {
                  _context = new ApplicationDbContext();
            }

            public ActionResult Transportador()
            {
                  var transportadoras = _context.Transportadoras.ToList();
                  return View(transportadoras);
            }

            public ActionResult Index()
            {
                  return View();
            }

            public ActionResult Detalhe(int id)
            {
                  var transportadoras = _context.Transportadoras.ToList();
                  return View(transportadoras.Find(transportador => transportador.Id == id));
            }

            //CRUD start here:

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Save(Transportador transportador)
            {
                  if (!ModelState.IsValid)
                  {
                        var viewModel = new TransportadorFormViewModel
                        {
                              Transportador = transportador
                        };
                        return View("FormTransportador", viewModel);
                  }

                  if (transportador.Id == 0)
                  {
                        _context.Transportadoras.Add(transportador);
                  }
                  else
                  {
                        var transportadorInDb = _context.Transportadoras.Single(c => c.Id == transportador.Id);

                        transportadorInDb.Nome = transportador.Nome;
                        transportadorInDb.Fone = transportador.Fone;
                        transportadorInDb.RegioesAtendidas = transportador.RegioesAtendidas;
                        transportadorInDb.Logo = transportador.Logo;
                      
                  }

                  // faz a persistência
                  _context.SaveChanges();
                  // Voltamos para a lista de transportadoras
                  return RedirectToAction("Transportador");
            }


            public ActionResult Edit(int id)
            {

                  var transportador = this._context.Transportadoras.SingleOrDefault(m => m.Id == id);

                  if (transportador == null)
                        return HttpNotFound();



                  var transportadorViewModel = new TransportadorFormViewModel()
                  {
                        Transportador = transportador
                  };


                  return View("FormTransportador", transportadorViewModel);
            }

            public ActionResult New()
            {

                  var transportadorViewModel = new TransportadorFormViewModel
                  {
                        Transportador = new Transportador()
                  };

                  return View("FormTransportador", transportadorViewModel);

            }
            [HttpPost]
            public ActionResult Delete(int id)
            {
                  var transportador = this._context.Transportadoras.Find(id);

                  if (transportador != null)
                  {

                        this._context.Transportadoras.Remove(transportador);
                        this._context.SaveChanges();

                  }

                  return RedirectToAction("Transportador");


            }



            protected override void Dispose(bool disposing)
            {
                  _context.Dispose();
            }
      }
}

