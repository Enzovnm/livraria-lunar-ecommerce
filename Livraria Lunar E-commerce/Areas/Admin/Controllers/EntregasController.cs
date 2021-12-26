using Livraria_Lunar_E_commerce.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Livraria_Lunar_E_commerce.Areas.Admin.Controllers
{
    public class EntregasController : Controller
    {
        // GET: Admin/Entregas
        public ActionResult Consultar()
        {

            if (Session["usuariologado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Login", "Login", new { area = "" });
            }

            
            if (Session["tipologado2"] == null && Session["tipologado3"] == null)
            {
                return RedirectToAction("semAcesso", "Login", new { area = "" });
            }


            EntregaAcoes acEntrega = new EntregaAcoes();
            return View(acEntrega.Consultar());
        }
    }
}