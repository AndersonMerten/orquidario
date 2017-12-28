using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleEstoque.Models
{
      public class Devedor
      {
            [Required]
            public int Id { get; set; }

            [Required(ErrorMessage = "Digite o nome de quem está devendo!")]
            public string Cliente { get; set; }

            [Required(ErrorMessage = "Digite o valor devido!")]
            [Range(0, float.MaxValue, ErrorMessage = "Digite um valor válido!")]
            public float ValorDevido { get; set; }
            [Required(ErrorMessage = "Digite o contato do cliente devedor!")]
            public string Contato { get; set; }
        
            public string Observacoes { get; set; }
      }
}