using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Livraria_Lunar_E_commerce.Areas.Admin.Controllers
{
    public class AdministradoresController : Controller
    {
        // GET: Admin/Administradores
        public ActionResult Cadastrar()
        {
            return View();
        }
    }
}