using Livraria_Lunar_E_commerce.Data;
using Livraria_Lunar_E_commerce.Models;
using MySql.Data.MySqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Livraria_Lunar_E_commerce.Business
{
    public class ComentarioAcoes
    {
        public void Cadastrar(Comentarios dto)
        {
            Conexao con = new Conexao();

            MySqlCommand cmd = new MySqlCommand("call sp_InsComentario(@ds_comentario, @cd_usuario);", con.MyConectarBD());

            cmd.Parameters.Add("@ds_comentario", MySqlDbType.VarChar).Value = dto.ds_comentario;
            cmd.Parameters.Add("@cd_usuario", MySqlDbType.VarChar).Value = dto.cd_usuario;

            cmd.ExecuteNonQuery();
            con.MyConectarBD();
        }

        public void Excluir(int id)
        {
            Conexao con = new Conexao();

            MySqlCommand cmd = new MySqlCommand("call sp_ExcComentario(@CodComentario);", con.MyConectarBD());

            cmd.Parameters.Add("@CodComentario", MySqlDbType.Int32).Value = id; 

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public List<Comentarios> Consultar()
        {
            Conexao con = new Conexao();

            var listaComentario = new List<Comentarios>();
            MySqlCommand cmd = new MySqlCommand("call sp_MostraComentario;", con.MyConectarBD());
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable tabela = new DataTable();

            adapter.Fill(tabela);

            foreach (DataRow dr in tabela.Rows)
            {
                listaComentario.Add(
                    new Comentarios
                    {
                        cd_comentario = int.Parse(dr["cd_comentario"].ToString()),
                        ds_comentario = Convert.ToString(dr["ds_comentario"]),
                        cd_usuario = int.Parse(dr["cd_usuario"].ToString()),
                        nm_usuario = Convert.ToString(dr["nm_usuario"]),
                        dt_comentario = DateTime.Parse(Convert.ToString(dr["dt_comentario"])).Date
                    });
            }
            return listaComentario;
        }

    }
}