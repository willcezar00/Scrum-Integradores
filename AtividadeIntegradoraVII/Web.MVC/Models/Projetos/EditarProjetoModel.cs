using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio.Entidades;
using Web.MVC.Models.Programador;

namespace Web.MVC.Models.Projetos
{
    public class EditarProjetoModel
    {
        public DadosProjetoModel DadosProjeto { get; set; }

        public List<ProgramadorModel> Programadores { get; set; }=new List<ProgramadorModel>();

        public List<ProgramadorModel> ProgramdoresDoProjeto { get; set; }= new List<ProgramadorModel>();

        public List<string> ProgramadoresDoProjetoId { get; set; } = new List<string>();

        public EditarProjetoModel()
        {

        }

    }
}