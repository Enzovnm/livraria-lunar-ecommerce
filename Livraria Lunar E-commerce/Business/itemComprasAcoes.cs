using Livraria_Lunar_E_commerce.Data;
using Livraria_Lunar_E_commerce.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Livraria_Lunar_E_commerce.Business
{
    public class itemComprasAcoes
    {
        public void inserirItem(ItemCompra dto)
        {
         Conexao con = new Conexao();

            MySqlCommand cmd = new MySqlCommand("call sp_InsItemCompras(@cd_compra, @cd_produto, @qtdeVendas)", con.MyConectarBD());

            cmd.Parameters.Add("@cd_compra", MySqlDbType.VarChar).Value = dto.cd_compra;
            cmd.Parameters.Add("@cd_produto", MySqlDbType.VarChar).Value = dto.cd_produto;
            cmd.Parameters.Add("@qtdeVendas", MySqlDbType.VarChar).Value = dto.qtdeVendas;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
    }
}