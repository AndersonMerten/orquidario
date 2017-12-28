using ControleEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleEstoque.ViewModels
{
      public class DevedorFormViewModel
      {
            public Devedor Devedor;
            public string Title
            {
                  get
                  {
                        if (this.Devedor != null && this.Devedor.Id != 0)
                              return "Edita Cliente";

                        return "Novo Cliente";
                  }
            }

      }
}