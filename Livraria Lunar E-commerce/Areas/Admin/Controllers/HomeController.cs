using Livraria_Lunar_E_commerce.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Livraria_Lunar_E_commerce.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    public class HomeController : Controller
    {



        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["usuariologado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Login", "Login", new { area = "" });
            }

            
            if (Session["tipologado2"] == null && Session["tipologado3"] == null)
            {
                return RedirectToAction("semAcesso", "Login", new { area = "" });
            }
            
            DashboardAcoes acDashboard = new DashboardAcoes(); 
            return View(acDashboard.Consultar());
        }
    }
}