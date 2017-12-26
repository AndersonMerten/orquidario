using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControleEstoque.Models
{
      [Table("Transportadores")]
      public class Transportador
      {
            public int Id { get; set; }
            [Required(ErrorMessage = "Você precisa digitar um nome!")]
            [StringLength(100, ErrorMessage = "O nome não pode ter mais que 100 caracteres!")]
            public string Nome { get; set; }
            [Required]
            [StringLength(12, ErrorMessage = "O número do telefone não pode ter mais que 12 caracteres!")]
            public string Fone { get; set; }
            [Required]
            public string RegioesAtendidas { get; set; }
            [Required]
            public string Logo { get; set; }

      }
}