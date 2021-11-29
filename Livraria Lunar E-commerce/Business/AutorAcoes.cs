using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Livraria_Lunar_E_commerce.Models;
using MySql.Data.MySqlClient;
using Livraria_Lunar_E_commerce.Data;

namespace Livraria_Lunar_E_commerce.Business
{
    public class AutorAcoes
    {
        public void Cadastrar(Autor dto)
        {
            Conexao con = new Conexao();

            MySqlCommand cmd = new MySqlCommand("call sp_InsAutor(@nm_autor, @ds_status);", con.MyConectarBD());
            
            cmd.Parameters.Add("@nm_autor", MySqlDbType.VarChar).Value = dto.nm_autor;
            cmd.Parameters.Add("@ds_status", MySqlDbType.VarChar).Value = dto.ds_status;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public void Alterar(Autor dto)
        {
            Conexao con = new Conexao();

            MySqlCommand cmd = new MySqlCommand("call sp_AltAutor(@CodAutor, @nm_autor, @ds_status);", con.MyConectarBD());

            cmd.Parameters.Add("@CodAutor", MySqlDbType.VarChar).Value = dto.cd_autor;
            cmd.Parameters.Add("@nm_autor", MySqlDbType.VarChar).Value = dto.nm_autor;
            cmd.Parameters.Add("@ds_status", MySqlDbType.VarChar).Value = dto.ds_status;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public List<Autor> Consultar()
        {
            Conexao con = new Conexao();

            var listaAutor = new List<Autor>();
            MySqlCommand cmd = new MySqlCommand("call sp_MostraAutor;", con.MyConectarBD());
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable tabela = new DataTable();

            adapter.Fill(tabela);

            foreach (DataRow dr in tabela.Rows)
            {
                listaAutor.Add(
                    new Autor
                    {
                        cd_autor = int.Parse(dr["cd_autor"].ToString()),
                        nm_autor = Convert.ToString(dr["nm_autor"]),
                        ds_status = int.Parse(dr["ds_status"].ToString())
                    });   
            } 

            return listaAutor;
        }
    }
}