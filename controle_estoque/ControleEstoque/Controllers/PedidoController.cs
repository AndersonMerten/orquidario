using ControleEstoque.Models;
using ControleEstoque.ViewModels;
using System.Data.Entity;
using System.Linq;

using System.Web.Mvc;

namespace ControleEstoque.Controllers
{

      [Authorize]
      public class PedidoController : Controller
      {
            private ApplicationDbContext _context= new ApplicationDbContext();

            public PedidoController()
            {
                  _context.Pedidos.Include(c => c.Cliente).ToList();
                  _context.Pedidos.Include(t => t.Transportadora).ToList();
                  _context.Pedidos.Include(p => p.Produto).ToList();
            }

            public ActionResult Pedido()
            {
                  var pedidos = _context.Pedidos.ToList();
                  return View(pedidos);
            }

            public ActionResult Index()
            {
                  return View();
            }

            public ActionResult Detalhe(int id)
            {
                  var pedidos = _context.Pedidos.ToList();
                  return View(pedidos.Find(pedido => pedido.Id == id));
            }

            //CRUD start here:

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Save(Pedido pedido)
            {
                  if (!ModelState.IsValid)
                  {
                        var viewModel = new PedidoFormViewModel
                        {
                              Pedido = pedido
                        };
                        return View("FormPedido", viewModel);
                  }

                  if (pedido.Id == 0)
                  {
                        _context.Pedidos.Add(pedido);
                  }
                  else
                  {
                        var pedidoInDb = _context.Pedidos.Single(c => c.Id == pedido.Id);

                        pedidoInDb.Id = pedido.Id;
                        pedidoInDb.ProdutoId = pedido.ProdutoId;
                        pedidoInDb.ClienteId = pedido.ClienteId;
                        pedidoInDb.TransportadoraId = pedido.TransportadoraId;

                  }

                  // faz a persistência
                  _context.SaveChanges();
                  // Voltamos para a lista de pedidos
                  return RedirectToAction("Pedido");
            }


            public ActionResult Edit(int id)
            {

                  var pedido = this._context.Pedidos.SingleOrDefault(m => m.Id == id);

                  if (pedido == null)
                        return HttpNotFound();



                  var pedidoViewModel = new PedidoFormViewModel()
                  {
                        Pedido = pedido,
                        ListaClientes = this._context.Clientes.ToList(),
                        ListaProdutos = this._context.Produtos.ToList(),
                        ListaTransportadores = this._context.Transportadoras.ToList()
                  };


                  return View("FormPedido", pedidoViewModel);
            }

            public ActionResult New()
            {

                  var pedidoViewModel = new PedidoFormViewModel
                  {
                        ListaClientes = this._context.Clientes.ToList(),
                        ListaProdutos = this._context.Produtos.ToList(),
                        ListaTransportadores =this._context.Transportadoras.ToList(),
                        Pedido = new Pedido()
                  };

                  return View("FormPedido", pedidoViewModel);

            }
            [HttpPost]
            public ActionResult Delete(int id)
            {
                  var pedido = this._context.Pedidos.Find(id);

                  if (pedido != null)
                  {

                        this._context.Pedidos.Remove(pedido);
                        this._context.SaveChanges();

                  }

                  return RedirectToAction("Pedido");


            }



            protected override void Dispose(bool disposing)
            {
                  _context.Dispose();
            }
      }
}



