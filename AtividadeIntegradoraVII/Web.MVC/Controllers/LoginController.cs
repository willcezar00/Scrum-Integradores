using System.Web.Routing;

namespace Web.MVC.Controllers
{
    using Infra.Contexto;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;
    using Dominio.Entidades;
    using Web.MVC.Models;

    public class LoginController : Controller
    {
        private readonly Contexto _contexto = new Contexto();
        // GET: Login
        public void InitializeController(RequestContext context)
        {
            base.Initialize(context);
        }
        [HttpGet]
        public ActionResult Index()
        {
            Session.Clear();
            return View();
        }

        public JsonResult Index(string email , string senha )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Membership.ValidateUser(email, senha))
                    {
                        var pessoa = _contexto.Pessoas
                            .FirstOrDefault(l => l.Email == email && l.Senha == senha);

                        var sessao = new SessionModel
                        {
                            Pessoa = pessoa,
                            IsGerente = _contexto.Gerentes.Any(l => l.PessoaId == pessoa.PessoaId)
                        };

                        Session["Sessao"] = sessao;
                        Session["Nome"] = sessao.Pessoa.Nome;
                        return Json(new
                        {
                            redirectUrl = Url.Action($"Index", $"PainelDeControle"),
                            isRedirect = true
                        });
                    }
                  
                }
                return Json(false);
            }
            catch (Exception e)
            {
                return Json(false);
                throw;
            }
          
        }
    }
}