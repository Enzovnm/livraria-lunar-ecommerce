using Livraria_Lunar_E_commerce.Data;
using Livraria_Lunar_E_commerce.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Livraria_Lunar_E_commerce.Business
{
    public class LoginAcoes
    {
        public void TestarUsuario(Cliente dto)
        {
        Conexao con = new Conexao();
        MySqlCommand cmd = new MySqlCommand("select * from tbl_Usuario where ds_email = @email and ds_senha = @senha", con.MyConectarBD());
        cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = dto.ds_email;
        cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = dto.ds_senha;

        MySqlDataReader leitor;

        leitor = cmd.ExecuteReader();

        if (leitor.HasRows)
        {
            while (leitor.Read())
            {
                dto.cd_cliente = int.Parse(leitor["cd_usuario"].ToString());
                dto.ds_email = Convert.ToString(leitor["ds_email"]);
                dto.ds_senha = Convert.ToString(leitor["ds_senha"]);
                dto.ds_tipo = int.Parse(leitor["ds_tipo"].ToString());
            }
        }

        else
        {
            dto.ds_email = null;
            dto.ds_senha = null;
            dto.ds_tipo = 0;
        }

        con.MyDesConectarBD();

        }

    }
}