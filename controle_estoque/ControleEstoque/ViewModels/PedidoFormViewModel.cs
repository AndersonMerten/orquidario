using ControleEstoque.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleEstoque.ViewModels
{
      public class PedidoFormViewModel
      {
            public IEnumerable<Cliente> ListaClientes { get; set; }
            public IEnumerable<Transportador> ListaTransportadores { get; set; }
            public IEnumerable<Produto> ListaProdutos { get; set; }
            public Pedido Pedido;
            public string Title
            {
                  get
                  {
                        if (this.Pedido != null && this.Pedido.Id != 0)
                              return "Edita Pedido";

                        return "Novo Pedido";
                  }
            }
      }
}