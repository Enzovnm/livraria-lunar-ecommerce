﻿using Livraria_Lunar_E_commerce.Business;
using Livraria_Lunar_E_commerce.Models;
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

        [HttpPost]
        public ActionResult Cadastrar(Administradores admin)
        {
            if (ModelState.IsValid)
            {
                AdministradoresAcoes acAdmin = new AdministradoresAcoes();
                acAdmin.Cadastrar(admin);
                return RedirectToAction("Consultar");
            }
            return View();
        }

        public ActionResult Consultar()
        {
            AdministradoresAcoes acAdmin = new AdministradoresAcoes();
            return View(acAdmin.Consultar());
        }


        public ActionResult Editar(int id)
        {
            AdministradoresAcoes acAdmin = new AdministradoresAcoes();
            return View(acAdmin.Consultar().Find(dto => dto.cd_admin == id));
        }

        [HttpPost]
        public ActionResult Editar(Administradores dto)
        {
            if (ModelState.IsValid)
            {
                AdministradoresAcoes acAdmin = new AdministradoresAcoes();
                acAdmin.Alterar(dto);
                return RedirectToAction("Consultar");
            }

            return View();
        }

        public ActionResult Excluir(int id)
        {
            AdministradoresAcoes acAdmin = new AdministradoresAcoes();
            acAdmin.Excluir(id);
            return RedirectToAction("Consultar");
        }

    }
}