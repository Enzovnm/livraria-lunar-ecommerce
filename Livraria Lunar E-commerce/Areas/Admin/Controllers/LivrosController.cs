using Livraria_Lunar_E_commerce.Business;
using Livraria_Lunar_E_commerce.Data;
using Livraria_Lunar_E_commerce.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Livraria_Lunar_E_commerce.Areas.Admin.Controllers
{
    public class LivrosController : Controller
    {
        
        // GET: Admin/Livros
        public ActionResult Cadastrar()
        {
            if (Session["usuariologado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Login", "Login", new { area = "" });
            }

            
            if (Session["tipologado2"] == null && Session["tipologado3"] == null)
            {
                return RedirectToAction("semAcesso", "Login", new { area = "" });
            }

            DropDownAutor();
            DropDownEditora();
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Livros livro, HttpPostedFileBase file)
        {
            DropDownAutor();
            DropDownEditora();
            if (file == null)
            {
                ViewBag.imagem = "É necessário adicionar uma imagem ao produto";
            }

            else
            {
                if (ModelState.IsValid)
                {
                    string arquivo = Path.GetFileName(file.FileName);
                    string file2 = "/Imagens/" + Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Imagens"), arquivo);
                    file.SaveAs(_path);
                    livro.img_produto = file2;
                    LivrosAcoes acLivros = new LivrosAcoes();
                    acLivros.Cadastrar(livro);
                    return RedirectToAction("Consultar");
                }
            }

            return View();
        }


        public ActionResult Consultar(int? i) {
            if (Session["usuariologado"] == null || Session["senhaLogado"] == null)
            {
                return RedirectToAction("Login", "Login", new { area = "" });
            }

            
            if (Session["tipologado2"] == null && Session["tipologado3"] == null)
            {
                return RedirectToAction("semAcesso", "Login", new { area = "" });
            }

            LivrosAcoes acLivros = new LivrosAcoes();
            return View(acLivros.Consultar().ToPagedList(i ?? 1, 4));
        }

        public ActionResult Editar(int id)
        {
            DropDownAutor();
            DropDownEditora();
            LivrosAcoes acLivros = new LivrosAcoes();
            return View(acLivros.Consultar().Find(dto => dto.cd_produto == id));
        }

        [HttpPost]
        public ActionResult Editar(Livros livros, HttpPostedFileBase file)
        {
            DropDownAutor();
            DropDownEditora();
            if (file == null)
            {
                ViewBag.imagem = "É necessário adicionar uma imagem ao produto";
            }

            else
            {
                if (ModelState.IsValid)
                {
                    string arquivo = Path.GetFileName(file.FileName);
                    string file2 = "/Imagens/" + Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Imagens"), arquivo);
                    file.SaveAs(_path);
                    livros.img_produto = file2;
                    LivrosAcoes acLivros = new LivrosAcoes();
                    acLivros.Alterar(livros);
                    return RedirectToAction("Consultar");
                }
            }
            return View();
        }


        public ActionResult Excluir(int id)
        {
            LivrosAcoes acLivros = new LivrosAcoes();
            acLivros.Excluir(id);
            return RedirectToAction("Consultar");
        }

        private void DropDownAutor()
        {

            List<SelectListItem> autor = new List<SelectListItem>();
            Conexao con = new Conexao();
            MySqlCommand cmd = new MySqlCommand("select cd_autor, nm_autor from tbl_autor where ds_status = 1", con.MyConectarBD());
            MySqlDataReader rdr = cmd.ExecuteReader();


            while (rdr.Read())
            {
                autor.Add(new SelectListItem
                {
                    Text = rdr[1].ToString(),
                    Value = rdr[0].ToString()
                });
            }
            con.MyDesConectarBD();



            ViewBag.autor = new SelectList(autor, "Value", "Text");
        }

        private void DropDownEditora()
        {

            List<SelectListItem> editora = new List<SelectListItem>();
            Conexao con = new Conexao();
            MySqlCommand cmd = new MySqlCommand("select cd_editora, nm_editora from tbl_editora", con.MyConectarBD());
            MySqlDataReader rdr = cmd.ExecuteReader();


            while (rdr.Read())
            {
                editora.Add(new SelectListItem
                {
                    Text = rdr[1].ToString(),
                    Value = rdr[0].ToString()
                });
            }
            con.MyDesConectarBD();



            ViewBag.editora = new SelectList(editora, "Value", "Text");
        }

    }
}