using Livraria_Lunar_E_commerce.Business;
using Livraria_Lunar_E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Livraria_Lunar_E_commerce.Areas.Admin.Controllers
{
    public class ComentarioController : Controller
    {

        ComentarioAcoes acComentario = new ComentarioAcoes();
        Comentarios comentario = new Comentarios();

        // GET: Admin/Comentario
        public ActionResult Consultar()
        {
            ComentarioAcoes acComentario = new ComentarioAcoes();
            return View(acComentario.Consultar());
        }

        public ActionResult Excluir(int id)
        {
            ComentarioAcoes acComentario = new ComentarioAcoes();
            acComentario.Excluir(id);
            return RedirectToAction("Consultar");
        }
    }
}