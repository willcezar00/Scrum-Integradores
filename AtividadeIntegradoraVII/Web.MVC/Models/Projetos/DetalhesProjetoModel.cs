using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.MVC.Models.Mensagem;
using Web.MVC.Models.Programador;

namespace Web.MVC.Models.Projetos
{
    public class DetalhesProjetoModel
    {
        public DadosProjetoModel DadosProjetoModel { get; set; }

        public ICollection<MensagemModel> Mensagens { get; set; } 

        public ICollection<ProgramadorModel> Programadores { get; set; }

        public string Gerente { get; set; }
    }
}