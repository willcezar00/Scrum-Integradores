using Dominio.Entidades;
using Infra.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Contexto _contexto = new Contexto();
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        public JsonResult EmailUnico(string email)
        {
            try
            {
                var usuario = _contexto.Pessoas.FirstOrDefault(l => l.Email == email);

                return Json(usuario == null);
            }
            catch (Exception e)
            {
                return Json(false);
                throw;
            }
        }
        [HttpPost]
        public JsonResult PostCadastrar(string nome,string email,string senha,string cpf,int profissao)
        {
            try
            {
                var pessoa = new Pessoa
                {
                    Nome = nome,
                    Email = email,
                    Senha = senha,
                    Cpf = cpf
                };

                _contexto.Pessoas.Add(pessoa);
                _contexto.SaveChanges();

                switch (profissao)
                {
                    case (int) Pessoa.Profissao.Gerente:
                        var gerente = new Gerente {PessoaId = pessoa.PessoaId};
                        _contexto.Gerentes.Add(gerente);
                        break;

                    case (int) Pessoa.Profissao.Programador:
                        var programador = new Programador {PessoaId = pessoa.PessoaId};
                        _contexto.Programadores.Add(programador);
                        break;
                }
                _contexto.SaveChanges();

                LoginController login = new LoginController();
                login.InitializeController(this.Request.RequestContext);
                return login.Index(pessoa.Email,pessoa.Senha);
            }
            catch (Exception er)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}