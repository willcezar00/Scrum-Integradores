using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class ProgramadorProjeto
    {
        public int ProgramadorProjetoId { get; set; }

        public int ProjetoId { get; set; }

        public int GerenteId { get; set; }

        public virtual Gerente Gerente { get; set; }

        public int ProgramadorId { get; set; }

        public virtual Programador Programador { get; set; }

        public virtual Projeto Projeto { get; set; }

    }
}
