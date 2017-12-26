using ControleEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleEstoque.ViewModels
{
      public class TransportadorFormViewModel
      {
            public Transportador Transportador;
            public string Title
            {
                  get
                  {
                        if (this.Transportador != null && this.Transportador.Id != 0)
                              return "Edita Transportadora";

                        return "Nova Transportadora";
                  }
            }
      }
}


