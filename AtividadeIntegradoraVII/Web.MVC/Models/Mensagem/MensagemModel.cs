namespace Web.MVC.Models.Mensagem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Dominio.Entidades;
    public class MensagemModel
    {
        public int MensagemId { get; set; }

        public string Texto { get; set; }

        public MensagemModel(Mensagem mensagem)
        {
            Texto = mensagem.Conteudo;
            MensagemId = mensagem.MensagemId;
        }
    }
}