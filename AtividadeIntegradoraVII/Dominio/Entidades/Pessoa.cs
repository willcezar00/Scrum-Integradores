using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Pessoa
    {
        public int PessoaId { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Cpf { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        public string  Email { get; set; }

        public enum Profissao
        {
            Gerente = 0,
            Programador = 1
        }

    }
}
