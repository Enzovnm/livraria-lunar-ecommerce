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
    public class EntregaAcoes
    {
        public List<Entregas> Consultar()
        {
            Conexao con = new Conexao();

            var listaEntrega = new List<Entregas>();
            MySqlCommand cmd = new MySqlCommand("call sp_MostraEntrega;", con.MyConectarBD());
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable tabela = new DataTable();

            adapter.Fill(tabela);

            foreach(DataRow dr in tabela.Rows)
            {
                listaEntrega.Add(
                    new Entregas
                    {
                        cd_entrega = int.Parse(dr["cd_entrega"].ToString()),
                        cd_compra = Convert.ToString(dr["cd_compra"]),
                        nm_produto = Convert.ToString(dr["nm_produto"]),
                        vl_total = decimal.Parse(dr["vl_total"].ToString()),
                        nm_usuario = Convert.ToString(dr["nm_usuario"]),
                        dt_entrega = DateTime.Parse(dr["dt_entrega"].ToString()),
                        no_cep = Convert.ToString(dr["no_cep"]),
                        nm_logradouro = Convert.ToString(dr["nm_logradouro"]),
                        no_logradouro = Convert.ToString(dr["no_logradouro"]),
                        ds_complemento = Convert.ToString(dr["ds_complemento"]),
                    } );
            }
            return listaEntrega;
        }

    }
}