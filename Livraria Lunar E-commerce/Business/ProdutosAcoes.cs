using Livraria_Lunar_E_commerce.Data;
using Livraria_Lunar_E_commerce.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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

    }
}