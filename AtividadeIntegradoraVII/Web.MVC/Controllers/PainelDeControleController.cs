using Dominio.Entidades;
using Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.MVC.Models;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;
using Web.MVC.Models.PainelDecontrole;

namespace Web.MVC.Controllers
{
    public class PainelDeControleController : Controller
    {
        private readonly Contexto _contexto = new Contexto();
        // GET: PainelDeControle
        public ActionResult Index()
        {
            SessionModel sessao = (SessionModel)Session["Sessao"];
            if(sessao == null)
            {
                return RedirectToAction("Index", "Login");
            }
            List<PainelDeControleModel> painelDeControle = new List<PainelDeControleModel>();

            var projetoConfig = _contexto.ProgramadorProjeto
                .Where(x => x.Gerente.PessoaId == sessao.Pessoa.PessoaId ||
                            x.Programador.PessoaId == sessao.Pessoa.PessoaId)
                .Select(x => new { x.ProjetoId,x.Gerente,x.Projeto })
                .ToList().DistinctBy(l => l.ProjetoId);

            PainelDeControleModel.IsGerente = sessao.IsGerente;

            foreach (var cada in projetoConfig)
            {
                PainelDeControleModel painel = new PainelDeControleModel
                {
                    Gerente = cada.Gerente,
                    Projeto = cada.Projeto,
                    Programadores = _contexto.ProgramadorProjeto.Where(x => x.ProjetoId == cada.ProjetoId)
                        .Select(x => x.Programador)
                        .ToList()
                };
                painelDeControle.Add(painel);
            }
            return View(painelDeControle);
        }
    }
}