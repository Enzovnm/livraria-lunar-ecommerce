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
    public class PedidoAcoes
    {
        public List<Pedido> Consultar(int id)
        {
            Conexao con = new Conexao();

            var listaPedido = new List<Pedido>();
            MySqlCommand cmd = new MySqlCommand("sp_MostraPedido(@CodCli);", con.MyConectarBD());
            cmd.Parameters.Add("@CodCli", MySqlDbType.Int32).Value = id;
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable tabela = new DataTable();

            adapter.Fill(tabela);

            foreach(DataRow dr in tabela.Rows)
            {
                listaPedido.Add(
                    new Pedido
                    {
                        cd_compra = int.Parse(dr["cd_compra"].ToString()),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        vl_total = decimal.Parse(dr["vl_total"].ToString()),
                        dt_entrega = Convert.ToDateTime(dr["dt_entrega"])
                    } );
            }
            return listaPedido;
        }        
    }
}