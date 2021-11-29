using Livraria_Lunar_E_commerce.Business;
using Livraria_Lunar_E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Livraria_Lunar_E_commerce.Areas.Admin.Controllers
{
    public class EditoraController : Controller
    {
        // GET: Admin/Editora
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Editora editora)
        {
            if(ModelState.IsValid)
            {
                EditorasAcoes acEditora = new EditorasAcoes();
                acEditora.Cadastrar(editora);
                return RedirectToAction("Consultar");
            }

            return View();
        }

        public ActionResult Consultar(Editora editora)
        {
            EditorasAcoes acEditora = new EditorasAcoes();
            return View(acEditora.Consultar());
        }

        public ActionResult Editar(int id)
        {
            EditorasAcoes acEditora = new EditorasAcoes();
            return View(acEditora.Consultar().Find(dto => dto.cd_editora == id));
        }

        [HttpPost]
        public ActionResult Editar(Editora editora)
        {
            if(ModelState.IsValid)
            {
                EditorasAcoes acEditora = new EditorasAcoes();
                acEditora.Alterar(editora);
                return RedirectToAction("Consultar");
            }
            return View();
        }

        public ActionResult Excluir(int id)
        {
            EditorasAcoes acEditora = new EditorasAcoes();
            acEditora.Excluir(id);
            return RedirectToAction("Consultar");
        }
    }
}