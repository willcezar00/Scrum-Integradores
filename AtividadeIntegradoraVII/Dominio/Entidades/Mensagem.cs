using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Mensagem
    {
        public int MensagemId { get; set; }

        public string Titulo { get; set; }

        public string Conteudo { get; set; }

        public string  Assunto { get; set; }

        public int ProjetoId { get; set; }

        public virtual Projeto Projeto { get; set; }

        public Mensagem(string titulo, string conteudo,string assunto)
        {
            this.Titulo = titulo;
            this.Conteudo = conteudo;
            this.Assunto = assunto;
        }

        public Mensagem()
        {
            
        }
    }
}
