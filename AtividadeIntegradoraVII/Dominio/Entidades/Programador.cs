using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Programador
    {
        public int ProgramadorId { get; set; }

        public int PessoaId { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
