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

namespace Livraria_Lunar_E_commerce.Areas.Admin.Controllers
{
    public class ProdutosController : Controller
    {
        // GET: Admin/Produtos
        public ActionResult Cadastrar()
        {
            DropDownProduto();
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Produtos produto, HttpPostedFileBase file)
        {
            DropDownProduto();
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
                    produto.img_produto = file2;
                    ProdutosAcoes acProdutos = new ProdutosAcoes();
                    acProdutos.Cadastrar(produto);
                    
                }
            }
            
            return View();
        }

        /*
        public ActionResult Consultar(Produtos produto)
        {
            ProdutoAcoes acEditora = new EditorasAcoes();
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
            if (ModelState.IsValid)
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
        }*/


        private void DropDownProduto()
        {

            List<SelectListItem> categoria = new List<SelectListItem>();
            Conexao con = new Conexao();
            MySqlCommand cmd = new MySqlCommand("select cd_categoria,nm_categoria from tbl_categoria where nm_categoria != 'Livros' ", con.MyConectarBD());
            MySqlDataReader rdr = cmd.ExecuteReader();


            while (rdr.Read())
            {
                categoria.Add(new SelectListItem
                {
                    Text = rdr[1].ToString(),
                    Value = rdr[0].ToString()
                });
            }
            con.MyDesConectarBD();



            ViewBag.categoria = new SelectList(categoria, "Value", "Text");
        }
    }
}