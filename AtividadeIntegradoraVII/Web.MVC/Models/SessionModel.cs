using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio.Entidades;

namespace Web.MVC.Models
{
    public class SessionModel
    {
        public Pessoa Pessoa { get; set; }

        public bool IsGerente { get; set; }
    }
}