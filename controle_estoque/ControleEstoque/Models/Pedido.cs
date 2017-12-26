using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleEstoque.Models
{
    public class Pedido
    {

            public int Id { get; set; }
            public Cliente Cliente { get; set; }
            public int ClienteId { get; set; }
            public Transportador Transportadora { get; set; }
            public int TransportadoraId { get; set; }
            public Produto Produto { get; set; }
            public int ProdutoId { get; set; }

      }
}