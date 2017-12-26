using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleEstoque.Models
{
      public class Cliente
      {
            [Required]
            public int Id { get; set; }

            [Required(ErrorMessage = "Você precisa digitar um nome!")]
            [StringLength(100, ErrorMessage = "O nome não pode ter mais que 100 caracteres!")]
            public string Nome { get; set; }

            [Required]
            [StringLength(12, ErrorMessage = "O número do telefone não pode ter mais que 12 caracteres!")]
            public string Fone { get; set; }
            [Required]
            [StringLength(11, ErrorMessage = "O CPF deve conter apenas os 11 números!")]
            public string Cpf { get; set; }
            [Required(ErrorMessage = "Digite o valor do e-mail!")]
            [EmailAddress(ErrorMessage = "Digite um e-mail válido")]
            public string Email { get; set; }
            [Required]            
            public DateTime? Nascimento { get; set; }            
            [Required]
            public String Imagem { get; set; }

      }
}