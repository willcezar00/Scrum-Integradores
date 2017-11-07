using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio.Entidades;

namespace Web.MVC.Models.Projetos
{
    public class DadosProjetoModel
    {
        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        public string Titulo { get; set; }

        public string  Descricao { get; set; }

        public int  ProjetoId { get; set; }

        public string Status { get; set; }

        public  int[] ProgramadoresId { get; set; }

        public DadosProjetoModel()
        {
            
        }

        public DadosProjetoModel(Projeto projeto)
        {
            this.DataFim = projeto.DataFim;
            this.DataInicio = projeto.DataInicio;
            this.Descricao = projeto.Descricao;
            this.Status = projeto.Status;
            this.Titulo = projeto.Titulo;
           
        }

    }
}