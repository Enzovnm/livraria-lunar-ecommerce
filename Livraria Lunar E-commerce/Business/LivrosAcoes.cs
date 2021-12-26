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
    public class LivrosAcoes
    {

        public void Cadastrar(Livros dto)
        {
            Conexao con = new Conexao();

            MySqlCommand cmd = new MySqlCommand("Call sp_InsProdutosLivros(@nm_produto, @qt_estoque, @vl_unitario, @img_produto, @desc_produto, " +
                "@cd_produto, @no_paginas,@no_isbn,@dt_publicada,@cd_autor,@cd_editora);", con.MyConectarBD());

            cmd.Parameters.Add("@nm_produto", MySqlDbType.VarChar).Value = dto.nm_produto;
            cmd.Parameters.Add("@qt_estoque", MySqlDbType.VarChar).Value = dto.qt_estoque;
            cmd.Parameters.Add("@vl_unitario", MySqlDbType.Decimal).Value = dto.vl_unitario;
            cmd.Parameters.Add("@img_produto", MySqlDbType.VarChar).Value = dto.img_produto;
            cmd.Parameters.Add("@desc_produto", MySqlDbType.VarChar).Value = dto.desc_produto;
            cmd.Parameters.Add("@cd_produto", MySqlDbType.VarChar).Value = dto.cd_produto;
            cmd.Parameters.Add("@no_paginas", MySqlDbType.Int32).Value = dto.no_paginas;
            cmd.Parameters.Add("@no_isbn", MySqlDbType.VarChar).Value = dto.no_isbn;
            cmd.Parameters.Add("@dt_publicada", MySqlDbType.Date).Value = dto.dt_publicada.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@cd_autor", MySqlDbType.Int32).Value = dto.cd_autor;
            cmd.Parameters.Add("@cd_editora", MySqlDbType.Int32).Value = dto.cd_editora;
            

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();


        }

        
        public List<Livros> Consultar()
        {
            Conexao con = new Conexao();

            var listaProdutoLivro = new List<Livros>();
            MySqlCommand cmd = new MySqlCommand("call sp_MostraProdutosLivros();", con.MyConectarBD());
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable tabela = new DataTable();

            adapter.Fill(tabela);

            foreach (DataRow dr in tabela.Rows)
            {
                listaProdutoLivro.Add(
                    new Livros
                    {
                        cd_produto = int.Parse(dr["cd_produto"].ToString()),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        vl_unitario = Decimal.Parse(dr["vl_unitario"].ToString()),
                        qt_estoque = int.Parse(dr["qt_estoque"].ToString()),
                        desc_produto = Convert.ToString(dr["desc_produto"]),
                        dt_publicada = DateTime.Parse(dr["dt_publicada"].ToString()),
                        img_produto = Convert.ToString(dr["img_produto"]),
                        no_paginas = int.Parse(dr["no_paginas"].ToString()),
                        no_isbn = Convert.ToString(dr["no_isbn"]),
                        cd_autor = int.Parse(dr["cd_autor"].ToString()),
                        nm_autor = Convert.ToString(dr["nm_autor"]),
                        cd_editora = int.Parse(dr["cd_editora"].ToString()),
                        nm_editora = Convert.ToString(dr["nm_editora"])
                    });
            }
            return listaProdutoLivro;
        }

        
        public void Alterar(Livros dto)
        {
            Conexao con = new Conexao();

            MySqlCommand cmd = new MySqlCommand("Call sp_AltProdutosLivros(@CodProduto,@nm_produto, @qt_estoque, @vl_unitario, @img_produto, @desc_produto, " +
                "@cd_produto, @no_paginas,@no_isbn,@dt_publicada,@cd_autor,@cd_editora);", con.MyConectarBD());


            cmd.Parameters.Add("@CodProduto", MySqlDbType.Int32).Value = dto.cd_produto;
            cmd.Parameters.Add("@nm_produto", MySqlDbType.VarChar).Value = dto.nm_produto;
            cmd.Parameters.Add("@qt_estoque", MySqlDbType.VarChar).Value = dto.qt_estoque;
            cmd.Parameters.Add("@vl_unitario", MySqlDbType.Decimal).Value = dto.vl_unitario;
            cmd.Parameters.Add("@img_produto", MySqlDbType.VarChar).Value = dto.img_produto;
            cmd.Parameters.Add("@desc_produto", MySqlDbType.VarChar).Value = dto.desc_produto;
            cmd.Parameters.Add("@cd_produto", MySqlDbType.VarChar).Value = dto.cd_produto;
            cmd.Parameters.Add("@no_paginas", MySqlDbType.Int32).Value = dto.no_paginas;
            cmd.Parameters.Add("@no_isbn", MySqlDbType.VarChar).Value = dto.no_isbn;
            cmd.Parameters.Add("@dt_publicada", MySqlDbType.Date).Value = dto.dt_publicada.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@cd_autor", MySqlDbType.Int32).Value = dto.cd_autor;
            cmd.Parameters.Add("@cd_editora", MySqlDbType.Int32).Value = dto.cd_editora;


            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        
        public void Excluir(int id)
        {
            Conexao con = new Conexao();

            MySqlCommand cmd = new MySqlCommand("call sp_ExcProdutoLivro(@CodProduto);", con.MyConectarBD());

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


    }
}