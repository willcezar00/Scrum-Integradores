

using System.Data.Entity;
using Web.MVC.Models.Mensagem;
using Web.MVC.Models.Programador;

namespace Web.MVC.Controllers
{
    using Web.MVC.Filtros;
    using Dominio.Entidades;
    using Infra.Contexto;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Bibliotecas.Enum;
    using Web.MVC.Models;
    using Web.MVC.Models.Projetos;

    [JsonAllowGet]
    public class ProjetoController : Controller
    {
        private readonly Contexto _contexto = new Contexto();
        // GET: Projeto
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Editar(int projetoId)
        {
            var editarProjetoModel = new EditarProjetoModel();

            var projeto = _contexto.Projetos.FirstOrDefault(l => l.ProjetoId == projetoId);

            editarProjetoModel.DadosProjeto = new DadosProjetoModel(projeto);

            #region Todos Programadores

            var programadores = _contexto.Programadores
                .Select(l => new { l.ProgramadorId, l.Pessoa.Nome })
                .ToList();


            foreach (var programador in programadores)
            {
                var programadorModel = new ProgramadorModel()
                {
                    Nome = programador.Nome,
                    ProgramadorId = programador.ProgramadorId
                };
                editarProjetoModel.Programadores.Add(programadorModel);
            }

            #endregion

            #region Programadores do Projeto
          
            var programadoresDoProjeto = _contexto.ProgramadorProjeto
                .Where(l => l.ProjetoId == projetoId)
                .Select(l => new { l.ProgramadorId, l.Programador.Pessoa.Nome })
                .ToList();
            
            foreach (var programadorDoProjeto in programadoresDoProjeto)
            {
                var programadorModel = new ProgramadorModel()
                {
                    Nome = programadorDoProjeto.Nome,
                    ProgramadorId = programadorDoProjeto.ProgramadorId
                };
                editarProjetoModel.ProgramadoresDoProjetoId.Add(programadorDoProjeto.ProgramadorId.ToString());
                editarProjetoModel.ProgramdoresDoProjeto.Add(programadorModel);
            }
            #endregion

            editarProjetoModel.DadosProjeto.ProjetoId = projetoId;
            return View(editarProjetoModel);
        }

        [HttpPost]
        public JsonResult Editar(DadosProjetoModel dadosProjetoModel)
        {
            try
            {
                var projeto = _contexto.Projetos.FirstOrDefault(l => l.ProjetoId == dadosProjetoModel.ProjetoId);

                if (projeto == null) return Json(false);

                projeto.DataFim = dadosProjetoModel.DataFim;
                projeto.DataInicio = dadosProjetoModel.DataInicio;
                projeto.Titulo = dadosProjetoModel.Titulo;
                projeto.Descricao = dadosProjetoModel.Descricao;

                _contexto.Entry(projeto).State = EntityState.Modified;
                _contexto.SaveChanges();

                var sessao = (SessionModel)Session["Sessao"];
                var gerente = _contexto.Gerentes
                    .FirstOrDefault(x => x.PessoaId == sessao.Pessoa.PessoaId);

                #region Atualizando programadores

                var todosProgramadoresDoProjeto = _contexto.ProgramadorProjeto
                    .Where(l => l.ProjetoId == dadosProjetoModel.ProjetoId)
                    .ToList();

                foreach (ProgramadorProjeto programadorProjeto in todosProgramadoresDoProjeto.ToList())
                {
                    _contexto.ProgramadorProjeto.Remove(programadorProjeto);
                    _contexto.SaveChanges();
                }
                foreach (int programadorId in dadosProjetoModel.ProgramadoresId)
                {
                    var programadorProjeto = new ProgramadorProjeto
                    {
                        ProjetoId = projeto.ProjetoId,
                        GerenteId = gerente.GerenteId,
                        ProgramadorId = programadorId
                    };
                    _contexto.ProgramadorProjeto.Add(programadorProjeto);
                    _contexto.SaveChanges();
                }

                #endregion

                return this.Json(new
                {
                    redirectUrl = Url.Action("Index", "PainelDeControle"),
                    isRedirect = true
                });
            }
            catch (Exception e)
            {
                return Json(false);
                throw;
            }
        }
     
      

        public ActionResult Avaliar(int projetoId)
        {
            try
            {
                var projeto = _contexto.Projetos.FirstOrDefault(l => l.ProjetoId == projetoId);

                var dadosProjeto = new DadosProjetoModel(projeto) {ProjetoId = projetoId};

                return View(dadosProjeto);
            }
            catch (Exception e)
            {
                return Json(false);
                throw;
            }
            
        }
        [HttpPost]
        public ActionResult Avaliar(AvaliarProjeto avaliarProjeto)
        {
            try
            {
                var projeto = _contexto.Projetos.FirstOrDefault(l => l.ProjetoId == avaliarProjeto.ProjetoId);

                if (projeto == null) return Json(false);

                projeto.Status = avaliarProjeto.Status;
                _contexto.Entry(projeto).State = EntityState.Modified;
                _contexto.SaveChanges();

                if (!string.IsNullOrEmpty(avaliarProjeto.Mensagem))
                {
                    Mensagem mensagem = new Mensagem()
                    {
                        Conteudo = avaliarProjeto.Mensagem,
                        ProjetoId = avaliarProjeto.ProjetoId
                    };
                    _contexto.Mensagens.Add(mensagem);
                    _contexto.SaveChanges();
                }
                return Json(new
                {
                    redirectUrl = Url.Action($"Index", $"PainelDeControle"),
                    isRedirect = true
                });
            }
            catch (Exception e)
            {
                return Json(false);
                throw;
            }

        }
        public ActionResult Cadastrar()
        {
            var programadores = _contexto.Programadores
                .Select(l => new {l.ProgramadorId, l.Pessoa.Nome})
                .ToList();

            var programadoresModel = new List<ProgramadorModel>();
;           foreach (var programador in programadores)
            {
                var programadorModel = new ProgramadorModel()
                {
                    Nome = programador.Nome,
                    ProgramadorId = programador.ProgramadorId
                };
                programadoresModel.Add(programadorModel);
            }
            return View(programadoresModel);
        }

        public JsonResult Excluir(int projetoId)
        {
            try
            {
                var projeto = _contexto.Projetos.FirstOrDefault(l => l.ProjetoId == projetoId);

                if (projeto == null) return Json(false);

                _contexto.Projetos.Remove(projeto);
                _contexto.SaveChanges();

                return Json(true);
            }
            catch (Exception e)
            {
                return Json(false);
                throw;
            }
        }

        public ActionResult Detalhes(int projetoId)
        {
            try
            {
                #region Projeto

                var projeto = _contexto.Projetos
                    .Include(l => l.Mensagens)
                    .FirstOrDefault(l => l.ProjetoId == projetoId);

                if (projeto == null) return Json(false);

                var dadosProjeto = new DadosProjetoModel(projeto) { ProjetoId = projetoId };

                #endregion

                #region Programadores

                var programadores = _contexto.ProgramadorProjeto
                    .Where(l => l.ProjetoId == projetoId)
                    .Select(l=>l.Programador)
                    .ToList();

                var programadoresModel = new List<ProgramadorModel>();
                foreach (Programador programador in programadores)
                {
                    var programadorModel = new ProgramadorModel(programador);
                    programadoresModel.Add(programadorModel);
                }

                #endregion

                #region Mensagens

                var mensagensModel = new List<MensagemModel>();
                foreach (Mensagem mensagem in projeto.Mensagens)
                {
                    var mensagemModel = new MensagemModel(mensagem);
                    mensagensModel.Add(mensagemModel);
                }
                

                #endregion

                var nomeGerente = _contexto.ProgramadorProjeto.Where(l => l.ProjetoId == projetoId)
                    .Select(l => l.Gerente.Pessoa.Nome)
                    .FirstOrDefault();

                var detalhesProjetoModel = new DetalhesProjetoModel()
                {
                    DadosProjetoModel = dadosProjeto,
                    Mensagens = mensagensModel,
                    Programadores =  programadoresModel,
                    Gerente = nomeGerente
                };
                return View(detalhesProjetoModel);
            }
            catch (Exception e)
            {
                return Json(false);
                throw;
            }
           
        }
        public JsonResult ConcluirProjeto(int projetoId)
        {
            try
            {
                var projeto = _contexto.Projetos.FirstOrDefault(l => l.ProjetoId == projetoId);

                if (projeto == null) return Json(false);

                projeto.Status = StatusProjeto.Concluido.Status;


                _contexto.Entry(projeto).State = EntityState.Modified;
                _contexto.SaveChanges();

                return Json(true);
            }
            catch (Exception)
            {
                Console.WriteLine();
                throw;
            }
        }

        public JsonResult PausarProjeto(int projetoId)
        {
            try
            {
                var projeto = _contexto.Projetos.FirstOrDefault(l => l.ProjetoId == projetoId);

                if (projeto == null) return Json(false);

                projeto.Status = StatusProjeto.Pausado.Status;


                _contexto.Entry(projeto).State = EntityState.Modified;
                _contexto.SaveChanges();

                return Json(true);
            }
            catch (Exception)
            {
                Console.WriteLine();
                throw;
            }
        }

        public JsonResult IniciarProjeto(int projetoId)
        {
            try
            {
                var projeto = _contexto.Projetos.FirstOrDefault(l => l.ProjetoId == projetoId);

                if (projeto == null) return Json(false);

                projeto.Status = StatusProjeto.Andamento.Status;

                
                _contexto.Entry(projeto).State = EntityState.Modified;
                _contexto.SaveChanges();

                return Json(true);
            }
            catch (Exception )
            {
                Console.WriteLine();
                throw;
            }

        }

        public JsonResult PostCadastrar(DadosProjetoModel dadosProjetoModel)
        {
            try
            {
                var projeto = new Projeto
                {
                    Titulo = dadosProjetoModel.Titulo,
                    DataInicio = dadosProjetoModel.DataInicio,
                    DataFim = dadosProjetoModel.DataFim,
                    Descricao = dadosProjetoModel.Descricao,
                    Status = StatusProjeto.NaoIniciado.Status
                };

                _contexto.Projetos.Add(projeto);
                _contexto.SaveChanges();

                var sessao = (SessionModel) Session["Sessao"];

                var gerente = _contexto.Gerentes
                    .FirstOrDefault(x => x.PessoaId == sessao.Pessoa.PessoaId);

                if (gerente == null) return Json(false);

                foreach (int programadorId in dadosProjetoModel.ProgramadoresId)
                {
                    var programadorProjeto = new ProgramadorProjeto
                    {
                        ProjetoId = projeto.ProjetoId,
                        GerenteId = gerente.GerenteId,
                        ProgramadorId = programadorId
                    };
                    _contexto.ProgramadorProjeto.Add(programadorProjeto);
                    _contexto.SaveChanges();
                }
                


                return Json(new
                {
                    redirectUrl = Url.Action($"Index", $"PainelDeControle"),
                    isRedirect = true
                });
            }
            catch (Exception er )
            {
                return Json(false);
            }
        }

      
    }
}