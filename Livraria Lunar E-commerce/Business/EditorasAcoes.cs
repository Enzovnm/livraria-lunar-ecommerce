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
    public class EditorasAcoes
    {
        public void Cadastrar(Editora dto)
        {
            Conexao con = new Conexao();

            MySqlCommand cmd = new MySqlCommand("call sp_InsEditora(@nm_editora);", con.MyConectarBD());

            cmd.Parameters.Add("@nm_editora", MySqlDbType.VarChar).Value = dto.nm_editora;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public void Alterar(Editora dto)
        {
            Conexao con = new Conexao();

            MySqlCommand cmd = new MySqlCommand("call sp_AltEditora(@CodEditora, @nm_editora);", con.MyConectarBD());

            cmd.Parameters.Add("@CodEditora", MySqlDbType.VarChar).Value = dto.cd_editora;
            cmd.Parameters.Add("@nm_editora", MySqlDbType.VarChar).Value = dto.nm_editora;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public List<Editora> Consultar()
        {
            Conexao con = new Conexao();

            var listaEditora = new List<Editora>();
            MySqlCommand cmd = new MySqlCommand("call sp_MostraEditora;", con.MyConectarBD());
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable tabela = new DataTable();

            adapter.Fill(tabela);

            foreach(DataRow dr in tabela.Rows)
            {
                listaEditora.Add(
                    new Editora
                    {
                        cd_editora = int.Parse(dr["cd_editora"].ToString()),
                        nm_editora = Convert.ToString(dr["nm_editora"])
                    });
            }
            return listaEditora;
        }

        public void Excluir(int id)
        {
            Conexao con = new Conexao();

            MySqlCommand cmd = new MySqlCommand("call sp_ExcEditora(@CodEditora);", con.MyConectarBD());

            cmd.Parameters.Add("@CodEditora", MySqlDbType.Int32).Value = id;

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