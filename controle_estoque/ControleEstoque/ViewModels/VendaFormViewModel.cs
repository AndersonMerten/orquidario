using ControleEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleEstoque.ViewModels
{
      public class VendaFormViewModel
      {
            public Venda Venda;
            public string Title
            {
                  get
                  {
                        if (this.Venda != null && this.Venda.Id != 0)
                              return "Edita Venda";

                        return "Nova Venda";
                  }
            }
      }
}