using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Tarefa
    {
        public int TarefaId { get; set; }

        public string Titulo { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime DataFinal { get; set; }

        public string Descricao { get; set; }

       
    }
}
