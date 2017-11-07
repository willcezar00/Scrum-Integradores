

namespace Web.MVC.Models.Programador
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Dominio.Entidades;
    public class ProgramadorModel
    {
        public int ProgramadorId { get; set; }

        public string Nome { get; set; }

        public ProgramadorModel(Programador programador)
        {
            ProgramadorId = programador.ProgramadorId;
            Nome = programador.Pessoa.Nome;
        }

        public ProgramadorModel()
        {
            
        }
    }
}