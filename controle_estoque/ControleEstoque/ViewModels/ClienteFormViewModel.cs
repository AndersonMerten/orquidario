using ControleEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleEstoque.ViewModels
{
      public class ClienteFormViewModel
      {
            public Cliente Cliente;
            public string Title
            {
                  get
                  {
                        if (this.Cliente != null && this.Cliente.Id != 0)
                              return "Edita Cliente";

                        return "Novo Cliente";
                  }
            }

      }
}