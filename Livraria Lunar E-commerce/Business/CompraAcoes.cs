using Livraria_Lunar_E_commerce.Data;
using Livraria_Lunar_E_commerce.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Livraria_Lunar_E_commerce.Business
{
    public class CompraAcoes
    {
        public void inserirVenda(Compra dto)
        {
            Conexao con = new Conexao();

            MySqlCommand cmd = new MySqlCommand("call sp_InsCompra(@vl_total, @cd_usuario)", con.MyConectarBD());
            cmd.Parameters.Add("@vl_total", MySqlDbType.Decimal).Value = dto.vl_total;
            cmd.Parameters.Add("@cd_usuario", MySqlDbType.VarChar).Value = dto.cd_cliente;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        MySqlDataReader dr;  

        public void buscaIdVenda(Compra dto)
        {
            Conexao con = new Conexao();
            MySqlCommand cmd = new MySqlCommand("call sp_buscaIdVenda;", con.MyConectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dto.cd_compra = int.Parse(dr[0].ToString());
            }
            con.MyDesConectarBD();
        }
    }
}