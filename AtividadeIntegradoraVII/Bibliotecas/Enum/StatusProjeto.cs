using System.Collections.Generic;

namespace Bibliotecas.Enum
{
    public class StatusProjeto
    {

        public static readonly StatusProjeto NaoIniciado = new StatusProjeto("Aguardando Inicio");
        public static readonly StatusProjeto Andamento = new StatusProjeto("Em Andamento");
        public static readonly StatusProjeto Pausado = new StatusProjeto("Pausado");
        public static readonly StatusProjeto Concluido = new StatusProjeto("Concluido");
        public static readonly StatusProjeto Aprovado = new StatusProjeto("Aprovado pelo Gerente");


        public string Status { get; private set; }

        public static IEnumerable<StatusProjeto> Values
        {
            get
            {
                yield return NaoIniciado;
                yield return Andamento;
                yield return Pausado;
                yield return Concluido;
                yield return Aprovado;


            }
        }

        public StatusProjeto(string diretorio)
        {
            this.Status = diretorio;
        }

    }
}

