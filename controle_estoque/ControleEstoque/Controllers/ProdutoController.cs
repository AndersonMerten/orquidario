using ControleEstoque.Models;
using ControleEstoque.ViewModels;
using System.Data.Entity;
using System.Linq;

using System.Web.Mvc;
namespace ControleEstoque.Controllers
{
      [Authorize]
      public class ProdutoController : Controller
      {
            private ApplicationDbContext _context;

            public ProdutoController()
            {
                  _context = new ApplicationDbContext();
            }

            public ActionResult Produto()
            {
                  var produtos = _context.Produtos.ToList();
                  return View(produtos);
            }

            public ActionResult Index()
            {
                  return View();
            }

            public ActionResult Detalhe(int id)
            {
                  var produtos = _context.Produtos.ToList();
                  return View(produtos.Find(produto => produto.Id == id));
            }

            //CRUD start here:

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Save(Produto produto)
            {
                  if (!ModelState.IsValid)
                  {
                        var viewModel = new ProdutoFormViewModel
                        {
                              Produto = produto
                        };
                        return View("FormProduto", viewModel);
                  }

                  if (produto.Id == 0)
                  {
                        _context.Produtos.Add(produto);
                  }
                  else
                  {
                        var produtoInDb = _context.Produtos.Single(c => c.Id == produto.Id);

                        produtoInDb.Nome = produto.Nome;
                        produtoInDb.Descricao = produto.Descricao;
                        produtoInDb.Preco = produto.Preco;
                        produtoInDb.Estoque = produto.Estoque;
                        produtoInDb.Foto = produto.Foto;
                  }

                  // faz a persistência
                  _context.SaveChanges();
                  // Voltamos para a lista de produtos
                  return RedirectToAction("Produto");
            }


            public ActionResult Edit(int id)
            {

                  var produto = this._context.Produtos.SingleOrDefault(m => m.Id == id);

                  if (produto == null)
                        return HttpNotFound();



                  var produtoViewModel = new ProdutoFormViewModel()
                  {
                        Produto = produto
                  };


                  return View("FormProduto", produtoViewModel);
            }

            public ActionResult New()
            {

                  var produtoViewModel = new ProdutoFormViewModel
                  {
                        Produto = new Produto()
                  };

                  return View("FormProduto", produtoViewModel);

            }
            [HttpPost]
            public ActionResult Delete(int id)
            {
                  var produto = this._context.Produtos.Find(id);

                  if (produto != null)
                  {

                        this._context.Produtos.Remove(produto);
                        this._context.SaveChanges();

                  }

                  return RedirectToAction("Produto");


            }



            protected override void Dispose(bool disposing)
            {
                  _context.Dispose();
            }
      }
}
