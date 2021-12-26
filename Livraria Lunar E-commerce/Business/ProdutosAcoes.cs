using Livraria_Lunar_E_commerce.Data;
using Livraria_Lunar_E_commerce.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Livraria_Lunar_E_commerce.Business
{
    public class ProdutosAcoes
    {
        public void Cadastrar(Produtos dto)
        {
            Conexao con = new Conexao();

            MySqlCommand cmd = new MySqlCommand("Call sp_InsProdutos(@nm_produto, @qt_estoque, @vl_unitario, @img_produto, @desc_produto, " +
                "@cd_categoria);", con.MyConectarBD());

            cmd.Parameters.Add("@nm_produto", MySqlDbType.VarChar).Value = dto.nm_produto;
            cmd.Parameters.Add("@qt_estoque", MySqlDbType.VarChar).Value = dto.qt_estoque;
            cmd.Parameters.Add("@vl_unitario", MySqlDbType.Decimal).Value = dto.vl_unitario;
            cmd.Parameters.Add("@img_produto", MySqlDbType.VarChar).Value = dto.img_produto;
            cmd.Parameters.Add("@desc_produto", MySqlDbType.VarChar).Value = dto.desc_produto;
            cmd.Parameters.Add("@cd_categoria", MySqlDbType.Int32).Value = dto.cd_categoria;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
            

        }


        public List<Produtos> Consultar()
        {
            Conexao con = new Conexao();

            var listaProduto = new List<Produtos>();
            MySqlCommand cmd = new MySqlCommand("call sp_MostraProdutos;", con.MyConectarBD());

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable tabela = new DataTable();

            adapter.Fill(tabela);

            foreach (DataRow dr in tabela.Rows)
            {
                listaProduto.Add(
                    new Produtos
                    {
                        cd_produto = int.Parse(dr["cd_produto"].ToString()),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        vl_unitario = Decimal.Parse(dr["vl_unitario"].ToString()),
                        qt_estoque = int.Parse(dr["qt_estoque"].ToString()),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        desc_produto = Convert.ToString(dr["desc_produto"]),
                        cd_categoria = int.Parse(dr["cd_categoria"].ToString()),
                        img_produto = Convert.ToString(dr["img_produto"])
                    });
            }
            return listaProduto;
        }



        public List<Produtos> ConsultarTodosProdutos()
        {
            Conexao con = new Conexao();

            var listaProduto = new List<Produtos>();
            MySqlCommand cmd = new MySqlCommand("call sp_MostraTodosProdutos();", con.MyConectarBD());
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable tabela = new DataTable();

            adapter.Fill(tabela);

            foreach (DataRow dr in tabela.Rows)
            {
                listaProduto.Add(
                    new Produtos
                    {
                        cd_produto = int.Parse(dr["cd_produto"].ToString()),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        vl_unitario = Decimal.Parse(dr["vl_unitario"].ToString()),
                        qt_estoque = int.Parse(dr["qt_estoque"].ToString()),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        desc_produto = Convert.ToString(dr["desc_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        no_isbn = Convert.ToString(dr["no_isbn"]),
                        nm_autor = Convert.ToString(dr["nm_autor"]),
                        nm_editora = Convert.ToString(dr["nm_editora"])
                    });
            }
            return listaProduto;
        }


        public List<Produtos> ConsultarporNome(string produto)
        {
            Conexao con = new Conexao();

            var listaProduto = new List<Produtos>();
            MySqlCommand cmd = new MySqlCommand("sp_MostraTodosProdutosporNome(@NomeProd);", con.MyConectarBD());
            cmd.Parameters.Add("@NomeProd", MySqlDbType.VarChar).Value = produto;
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable tabela = new DataTable();

            adapter.Fill(tabela);

            foreach (DataRow dr in tabela.Rows)
            {
                listaProduto.Add(
                    new Produtos
                    {
                        cd_produto = int.Parse(dr["cd_produto"].ToString()),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        vl_unitario = Decimal.Parse(dr["vl_unitario"].ToString()),
                        qt_estoque = int.Parse(dr["qt_estoque"].ToString()),
                        nm_categoria = Convert.ToString(dr["nm_categoria"]),
                        desc_produto = Convert.ToString(dr["desc_produto"]),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        no_isbn = Convert.ToString(dr["no_isbn"]),
                        nm_autor = Convert.ToString(dr["nm_autor"]),
                        nm_editora = Convert.ToString(dr["nm_editora"])
                    });
            }
            return listaProduto;
        }


        public void Alterar(Produtos dto)
        {
            Conexao con = new Conexao();

            MySqlCommand cmd = new MySqlCommand("call sp_AltProdutos(@CodProduto,@nm_produto, @qt_estoque, @vl_unitario, @img_produto, @desc_produto,@cd_categoria);", con.MyConectarBD());
            cmd.Parameters.Add("@CodProduto", MySqlDbType.Int32).Value = dto.cd_produto;
            cmd.Parameters.Add("@nm_produto", MySqlDbType.VarChar).Value = dto.nm_produto;
            cmd.Parameters.Add("@qt_estoque", MySqlDbType.VarChar).Value = dto.qt_estoque;
            cmd.Parameters.Add("@vl_unitario", MySqlDbType.Decimal).Value = dto.vl_unitario;
            cmd.Parameters.Add("@img_produto", MySqlDbType.VarChar).Value = dto.img_produto;
            cmd.Parameters.Add("@desc_produto", MySqlDbType.VarChar).Value = dto.desc_produto;
            cmd.Parameters.Add("@cd_categoria", MySqlDbType.Int32).Value = dto.cd_categoria;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public void Excluir(int id)
        {
            Conexao con = new Conexao();

            MySqlCommand cmd = new MySqlCommand("call sp_ExcProduto(@CodProduto);", con.MyConectarBD());

            cmd.Parameters.Add("@CodProduto", MySqlDbType.Int32).Value = id;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {

            }
            con.MyDesConectarBD();
        }


        public List<Produtos> GetConsProd(int id)
        {
            Conexao con = new Conexao();
            List<Produtos> Produtoslist = new List<Produtos>();
            MySqlCommand cmd = new MySqlCommand("call sp_ConsProd(@codProduto)", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@codProduto",id);
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sd.Fill(dt);
            con.MyDesConectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                Produtoslist.Add(
                    new Produtos
                    {
                        cd_produto = int.Parse(dr["cd_produto"].ToString()),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        vl_unitario = Decimal.Parse(dr["vl_unitario"].ToString()),
                        qt_estoque = int.Parse(dr["qt_estoque"].ToString()),
                        desc_produto = Convert.ToString(dr["desc_produto"]),
                        cd_categoria = int.Parse(dr["cd_categoria"].ToString()),
                        img_produto = Convert.ToString(dr["img_produto"])
                    });      
            }
            return Produtoslist;
        }

    }
}