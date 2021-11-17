using Livraria_Lunar_E_commerce.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Livraria_Lunar_E_commerce.Data;
using MySql.Data.MySqlClient;

namespace Livraria_Lunar_E_commerce.Business
{
    public class AdministradoresAcoes
    {
     
    
        public void Cadastrar(Administradores dto)
        {
            Conexao con = new Conexao();

            MySqlCommand cmd = new MySqlCommand("Call sp_InsAdministradores(@nm_usuario, @ds_email, @ds_senha, @no_cpf, @no_telefone, " +
                "@no_celular, @nm_logradouro, @no_logradouro, @nm_bairro, @nm_cidade,"+
                "@sg_uf, @no_cep, @sg_sexo, @ds_status, @ds_tipo);", con.MyConectarBD());

            cmd.Parameters.Add("@nm_usuario", MySqlDbType.VarChar).Value = dto.nm_admin;
            cmd.Parameters.Add("@ds_email", MySqlDbType.VarChar).Value = dto.ds_email;
            cmd.Parameters.Add("@ds_senha", MySqlDbType.VarChar).Value = dto.ds_senha;
            cmd.Parameters.Add("@no_cpf", MySqlDbType.VarChar).Value = dto.cpf;
            cmd.Parameters.Add("@no_telefone", MySqlDbType.VarChar).Value = dto.telefone;
            cmd.Parameters.Add("@no_celular", MySqlDbType.VarChar).Value = dto.celular;
            cmd.Parameters.Add("@nm_logradouro", MySqlDbType.VarChar).Value = dto.rua;
            cmd.Parameters.Add("@no_logradouro", MySqlDbType.VarChar).Value = dto.no_logradouro;
            cmd.Parameters.Add("@nm_bairro", MySqlDbType.VarChar).Value = dto.bairro;
            cmd.Parameters.Add("@nm_cidade", MySqlDbType.VarChar).Value = dto.cidade;
            cmd.Parameters.Add("@sg_uf", MySqlDbType.VarChar).Value = dto.uf;
            cmd.Parameters.Add("@no_cep", MySqlDbType.VarChar).Value = dto.cep;
            cmd.Parameters.Add("@sg_sexo", MySqlDbType.VarChar).Value = dto.sg_sexo;
            cmd.Parameters.Add("@ds_status", MySqlDbType.VarChar).Value = dto.ds_status;
            cmd.Parameters.Add("@ds_tipo", MySqlDbType.VarChar).Value = dto.ds_tipo;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();

        
        }

        public void Alterar(Administradores dto)
        {
            Conexao con = new Conexao();
            
            MySqlCommand cmd = new MySqlCommand("Call sp_AltAdministradores(@CodUsuario, @nm_usuario, @ds_email, @ds_senha, @no_cpf, @no_telefone," +
                "@no_celular, @nm_logradouro, @no_logradouro, @nm_bairro, @nm_cidade, @sg_uf,"+
                " @no_cep, @sg_sexo, @ds_status, @ds_tipo);", con.MyConectarBD());

            cmd.Parameters.Add("@nm_usuario", MySqlDbType.VarChar).Value = dto.nm_admin;
            cmd.Parameters.Add("@ds_email", MySqlDbType.VarChar).Value = dto.ds_email;
            cmd.Parameters.Add("@ds_senha", MySqlDbType.VarChar).Value = dto.ds_senha;
            cmd.Parameters.Add("@no_cpf", MySqlDbType.VarChar).Value = dto.cpf;
            cmd.Parameters.Add("@no_telefone", MySqlDbType.VarChar).Value = dto.telefone;
            cmd.Parameters.Add("@no_celular", MySqlDbType.VarChar).Value = dto.celular;
            cmd.Parameters.Add("@nm_logradouro", MySqlDbType.VarChar).Value = dto.rua;
            cmd.Parameters.Add("@no_logradouro", MySqlDbType.VarChar).Value = dto.no_logradouro;
            cmd.Parameters.Add("@nm_bairro", MySqlDbType.VarChar).Value = dto.bairro;
            cmd.Parameters.Add("@nm_cidade", MySqlDbType.VarChar).Value = dto.cidade;
            cmd.Parameters.Add("@sg_uf", MySqlDbType.VarChar).Value = dto.uf;
            cmd.Parameters.Add("@no_cep", MySqlDbType.VarChar).Value = dto.cep;
            cmd.Parameters.Add("@sg_sexo", MySqlDbType.VarChar).Value = dto.sg_sexo;
            cmd.Parameters.Add("@ds_status", MySqlDbType.VarChar).Value = dto.ds_status;
            cmd.Parameters.Add("@ds_tipo", MySqlDbType.VarChar).Value = dto.ds_tipo;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();

        }

        public List<>

    }

}

