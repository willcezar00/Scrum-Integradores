using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.MVC.Models.Projetos
{
    public class AvaliarProjeto
    {
        public int ProjetoId { get; set; }

        public string Mensagem { get; set; }

        public string Status { get; set; }
    }
}