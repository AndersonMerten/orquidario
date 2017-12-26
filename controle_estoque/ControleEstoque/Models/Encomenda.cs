using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleEstoque.Models
{
      public class Encomenda
      {
            [Required]
            public int Id { get; set; }

            [Required(ErrorMessage = "Digite o que vai ser encomendado!")]
            public string Produto { get; set; }

            [Required(ErrorMessage = "Digite o nome de quem encomendou!")]
            public string Cliente { get; set; }

            [Required(ErrorMessage = "Digite o contato de quem encomendou o produto!")]
            public string  Contato { get; set; }
            
            public string Foto { get; set; }
      }
}
