using ControleEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleEstoque.ViewModels
{
      public class ProdutoFormViewModel
      {
            public Produto Produto;
            public string Title
            {
                  get
                  {
                        if (this.Produto != null && this.Produto.Id != 0)
                              return "Edita Produto";

                        return "Novo Produto";
                  }
            }
      }
}