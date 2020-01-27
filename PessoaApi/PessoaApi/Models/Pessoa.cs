using System;
using System.ComponentModel.DataAnnotations;
using PessoaApi.CustomValidation;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

namespace PessoaApi.Models
{
    public class Pessoa
    {
        public long Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required]
        [CpfValidation]
        public string Cpf { get; set; }

        [Required]
        [UfValidation]
        public string Uf { get; set; }

        [DataNascimentoValidation]
        public DateTime DataNascimento { get; set; }
    }
}
