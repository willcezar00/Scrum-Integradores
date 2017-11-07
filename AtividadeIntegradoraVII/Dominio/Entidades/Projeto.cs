using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Projeto
    {
        public int ProjetoId { get; set; }

        public string Descricao { get; set; }

        public string  Titulo { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public string Status { get; set; }

        public ICollection<Mensagem> Mensagens { get; set; }
      
    }
}
