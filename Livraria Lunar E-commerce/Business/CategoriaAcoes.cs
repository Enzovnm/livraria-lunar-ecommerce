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
    public class CategoriaAcoes
    {
        public void Cadastrar(Categoria dto)
        {
            Conexao con = new Conexao();

            MySqlCommand cmd = new MySqlCommand("call sp_InsCategoria(@nm_categoria);", con.MyConectarBD());

            cmd.Parameters.Add("@nm_categoria", MySqlDbType.VarChar).Value = dto.nm_categoria;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();

        }

        public void Alterar(Categoria dto)
        {
            Conexao con = new Conexao();

            MySqlCommand cmd = new MySqlCommand("call sp_AltCategoria(@CodCategoria, @nm_categoria)", con.MyConectarBD());

            cmd.Parameters.Add("@CodCategoria", MySqlDbType.VarChar).Value = dto.cd_categoria;
            cmd.Parameters.Add("@nm_categoria", MySqlDbType.VarChar).Value = dto.nm_categoria;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public List<Categoria> Consultar()
        {
            Conexao con = new Conexao();

            var listaCategoria = new List<Categoria>();
            MySqlCommand cmd = new MySqlCommand("call sp_MostraCategoria;", con.MyConectarBD());
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable tabela = new DataTable();

            adapter.Fill(tabela);

            foreach (DataRow dr in tabela.Rows)

            {
                listaCategoria.Add(
                    new Categoria
                    {
                        cd_categoria = int.Parse(dr["cd_categoria"].ToString()),
                        nm_categoria = Convert.ToString(dr["nm_categoria"])        
                    });
            }

            return listaCategoria;
        }

        public int Excluir(int id)
        {
            Conexao con = new Conexao();

            MySqlCommand cmd = new MySqlCommand("call sp_ExcCategoria(@CodCategoria);", con.MyConectarBD());

            cmd.Parameters.Add("@CodCategoria", MySqlDbType.Int32).Value = id;


            try
            {
                cmd.ExecuteNonQuery();
            }

            catch
            {
                return 1;
            }

            con.MyDesConectarBD();
            return 0;
        }
    }
}