using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleEstoque.Models
{
      public class Venda
      {
            [Required]
            public int Id { get; set; }

            [Required(ErrorMessage = "Você precisa um valor!")]
            [Range(0, float.MaxValue, ErrorMessage = "Digite um valor válido!")]
            public float Valor { get; set; }

            [Required]
            [DataType(DataType.Date)]
            public DateTime Data { get; set; }
      }
}