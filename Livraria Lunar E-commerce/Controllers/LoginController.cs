using Livraria_Lunar_E_commerce.Business;
using Livraria_Lunar_E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Livraria_Lunar_E_commerce.Controllers
{
    public class LoginController : Controller
    {
        LoginAcoes log = new LoginAcoes();
        ClientesAcoes acCliente = new ClientesAcoes();
        // GET: Login

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Cliente login)
        {
                log.TestarUsuario(login);

                if (login.ds_email != null && login.ds_senha != null)
                {
                    FormsAuthentication.SetAuthCookie(login.ds_email, false);
                    
                    Session["usuarioLogado"] = login.ds_email.ToString();
                    Session["senhaLogado"] = login.ds_senha.ToString();
                    Session["cd_cliente"] = login.cd_cliente.ToString();

                    if (login.ds_tipo == 1)
                    {
                        Session["tipoLogado1"] = login.ds_tipo.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else if (login.ds_tipo == 2)
                    {
                        Session["tipoLogado2"] = login.ds_tipo.ToString();
                        return RedirectToAction("Index", "Home", new { area = "Admin" });

                    }
                    else
                    {
                        Session["tipoLogado3"] = login.ds_tipo.ToString(); //= 3 
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                }
                else
                {
                ViewBag.msg = "é necessário prencher os campos";
                    return RedirectToAction("Login", "Login");
                }
            }
        

        public ActionResult Logout()
        {
            Session["usuarioLogado"] = null;
            Session["nomeCliente"] = null;
            Session["usuarioLogado"] = null;
            Session["senhaLogado"] = null;
            Session["cd_cliente"] = null;
            Session["tipoLogado1"] = null;
            Session["tipoLogado2"] = null;
            Session["tipoLogado3"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login2(Cliente verLogin)
        {
            log.TestarUsuario(verLogin);

            if (verLogin.ds_email != null & verLogin.ds_senha != null)
            {
                FormsAuthentication.SetAuthCookie(verLogin.ds_email, false);
                Session["usuarioLogado"] = verLogin.ds_email.ToString();
                Session["senhaLogado"] = verLogin.ds_senha.ToString();
                Session["cd_cliente"] = verLogin.cd_cliente.ToString();

                return RedirectToAction("Carrinho", "Home");
            }
            else
            {
                ViewBag.msgLogar = "Usuário não encontrado. Verifique o nome do usuário e a senha";
                return View();
            }
            
        }

        public ActionResult semAcesso()
        {
            Response.Write("<script>alert('Sem acesso')</script>");
            ViewBag.message = "Você não tem acesso a essa página";

            return View();
        }
    }
}