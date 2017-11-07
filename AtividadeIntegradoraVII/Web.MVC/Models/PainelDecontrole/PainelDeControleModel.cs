using System.Collections.Generic;
using Dominio.Entidades;

namespace Web.MVC.Models.PainelDecontrole
{
    public class PainelDeControleModel
    {
        public Projeto Projeto { get; set; }

        public static bool IsGerente { get; set; }

        public List<Dominio.Entidades.Programador> Programadores { get; set; } = new List<Dominio.Entidades.Programador>();

        public Gerente Gerente { get; set; }

        public PainelDeControleModel()
        {
            
        }
    }
}