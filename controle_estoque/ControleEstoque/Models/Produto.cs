using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace ControleEstoque.Models
{
      [Table("Produtos")]
      public class Produto
      {     [Required]
            public int Id { get; set; }
            [Required]
            [StringLength(100, ErrorMessage = "O nome não pode ter mais que 100 caracteres!")]
            public string Nome { get; set; }
            [Required]
            [StringLength(100, ErrorMessage = "A descrição não pode ter mais que 150 caracteres!")]
            public string Descricao { get; set; }
            [Required]
            public double Preco { get; set; }
            [Required]
            public double Estoque { get; set; }
            [Required]
            public string Foto { get; set; }

      }
}