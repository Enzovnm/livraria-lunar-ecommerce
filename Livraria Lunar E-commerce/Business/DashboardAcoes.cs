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
    public class DashboardAcoes
    {

        public List<Dashboard> Consultar()
        {
            Conexao con = new Conexao();

            var listaDashboard = new List<Dashboard>();
            MySqlCommand cmd = new MySqlCommand("call sp_Dashboard;", con.MyConectarBD());
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable tabela = new DataTable();

            adapter.Fill(tabela);



                foreach (DataRow dr in tabela.Rows)
                {
                    listaDashboard.Add(
                        new Dashboard
                        {
                            
                            Caixa = Decimal.Parse(dr["Caixa"].ToString()),
                            Clientes = int.Parse(dr["Cliente"].ToString()),
                            Funcionarios = int.Parse(dr["Funcionarios"].ToString()),
                            Produtos = int.Parse(dr["Produtos"].ToString()),
                            Autores = int.Parse(dr["Autores"].ToString()),
                            Editora = int.Parse(dr["Editora"].ToString()),
                        });
                }
                return listaDashboard;
            

        }

    }
}