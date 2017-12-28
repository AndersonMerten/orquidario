using ControleEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleEstoque.ViewModels
{
      public class EncomendaFormViewModel
      {
            public Encomenda Encomenda;
            public string Title
            {
                  get
                  {
                        if (this.Encomenda != null && this.Encomenda.Id != 0)
                              return "Edita Encomenda";

                        return "Nova Encomenda";
                  }
            }

      }
}