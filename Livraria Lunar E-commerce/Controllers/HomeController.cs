using Livraria_Lunar_E_commerce.Business;
using Livraria_Lunar_E_commerce.Data;
using Livraria_Lunar_E_commerce.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Livraria_Lunar_E_commerce.Controllers
{

    public class HomeController : Controller
    {
        CompraAcoes acCompra = new CompraAcoes();
        itemComprasAcoes acItemCompras = new itemComprasAcoes();
        ProdutosAcoes acProdutos = new ProdutosAcoes();
        
        public ActionResult Index()
        {
          
            return View(acProdutos.ConsultarTodosProdutos());
        }

        public ActionResult ConsultaporNome(string produto)
        {
            return View(acProdutos.ConsultarporNome(produto));
        }

        public ActionResult Cadastrar()
        { 
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                ClientesAcoes acCliente = new ClientesAcoes();
                acCliente.Cadastrar(cliente);
                Session["usuarioLogado"] = cliente.ds_email.ToString();
                Session["senhaLogado"] = cliente.ds_senha.ToString();
                
                cliente.ds_tipo = 1;

                Conexao con = new Conexao();

               
                MySqlCommand cmd = new MySqlCommand("select cd_usuario from tbl_usuario order by  cd_usuario desc limit 1;", con.MyConectarBD());
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable tabela = new DataTable();

                adapter.Fill(tabela);
                int codigocliente = 0;

                foreach (DataRow dr in tabela.Rows)
                {
                    codigocliente = int.Parse(dr["cd_usuario"].ToString());
                }

                cliente.cd_cliente = codigocliente;
                Session["cd_cliente"] = cliente.cd_cliente.ToString();

                if (cliente.ds_tipo == 1)
                {
                    Session["tipoLogado1"] = cliente.ds_tipo.ToString();
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        public static string codigo;

        public ActionResult AdicionarCarrinho(int id, double pre,string img)
        { 
            ProdutosAcoes acProdutos = new ProdutosAcoes();
            CompraAcoes acCompra = new CompraAcoes();
            itemComprasAcoes acItemCompras = new itemComprasAcoes();

            Compra carrinho = Session["Carrinho"] != null ? (Compra)Session["Carrinho"] : new Compra();
            var produto = acProdutos.GetConsProd(id);
            codigo = id.ToString();

            Produtos prod = new Produtos();

            if (produto != null)
            {
                var itemCompras = new ItemCompra();
                itemCompras.cd_itemCompras = Guid.NewGuid();
                itemCompras.cd_produto = int.Parse(id.ToString());
                itemCompras.nm_produto = produto[0].nm_produto;
                itemCompras.qtdeVendas = 1;
                itemCompras.valorUnit = pre;
                itemCompras.img = img ;

                List<ItemCompra> x = carrinho.ItensDaCompra.FindAll(l => l.nm_produto == itemCompras.nm_produto);

                if(x.Count!=0)
                {
                    carrinho.ItensDaCompra.FirstOrDefault(p => p.nm_produto == produto[0].nm_produto).qtdeVendas +=1;
                    itemCompras.valorParcial = itemCompras.qtdeVendas * itemCompras.valorUnit;
                    carrinho.vl_total += itemCompras.valorParcial;
                    carrinho.ItensDaCompra.FirstOrDefault(p => p.nm_produto == produto[0].nm_produto).valorParcial = carrinho.ItensDaCompra.FirstOrDefault(p => p.nm_produto == produto[0].nm_produto).qtdeVendas * itemCompras.valorUnit;
                }

                else
                {
                    itemCompras.valorParcial = itemCompras.qtdeVendas * itemCompras.valorUnit;
                    carrinho.vl_total += itemCompras.valorParcial;
                    carrinho.ItensDaCompra.Add(itemCompras);
                }

                Session["Carrinho"] = carrinho;
            }

            return RedirectToAction("Carrinho");
        }


        public ActionResult Carrinho()
        {
            Compra carrinho = Session["Carrinho"] != null ? (Compra)Session["Carrinho"] : new Compra();

            return View(carrinho);
        }


        public ActionResult ExcluirItem(Guid id)
        {
            var carrinho = Session["Carrinho"] != null ? (Compra)Session["Carrinho"] : new Compra();
            var itemExclusao = carrinho.ItensDaCompra.FirstOrDefault(i => i.cd_itemCompras == id);

            carrinho.vl_total -= itemExclusao.valorParcial;

            carrinho.ItensDaCompra.Remove(itemExclusao);

            Session["Carrinho"] = carrinho;
            return RedirectToAction("Carrinho");
        }

        public ActionResult SalvarCarrinho(Compra x)
        {
            if((Session["usuarioLogado"] == null) || (Session["senhaLogado"] == null))
            {
                return RedirectToAction("Login2", "Login");
            }

            else
            {
                var carrinho = Session["Carrinho"] != null ? (Compra)Session["Carrinho"] : new Compra();

                Compra md = new Compra();
                ItemCompra mdv = new ItemCompra();


               

                md.cd_cliente = int.Parse(Session["cd_cliente"].ToString());
                md.vl_total = carrinho.vl_total;

                acCompra.inserirVenda(md);

                acCompra.buscaIdVenda(x);

                for (int i = 0; i < carrinho.ItensDaCompra.Count; i++)
                {
                    mdv.cd_compra = int.Parse(x.cd_compra.ToString());
                    mdv.cd_produto = carrinho.ItensDaCompra[i].cd_produto;
                    mdv.qtdeVendas = carrinho.ItensDaCompra[i].qtdeVendas;
                    mdv.valorParcial = carrinho.ItensDaCompra[i].valorParcial;
                    acItemCompras.inserirItem(mdv);
                }

                carrinho.vl_total = 0;
                carrinho.ItensDaCompra.Clear();

                return RedirectToAction("confVenda");
            }
        }

        public ActionResult Detalhes(int id)
        {

            return View(acProdutos.ConsultarTodosProdutos().Find(dto => dto.cd_produto == id));
        }


        public ActionResult confVenda()
        {
            return View() ;
        }

    }
}