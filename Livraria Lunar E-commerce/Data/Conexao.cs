﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Livraria_Lunar_E_commerce.Data
{
    public class Conexao
    {
        MySqlConnection cn = new MySqlConnection("Server=localhost; DataBase=db_Ecommerce; User=root;pwd=e1222");

        public static string msg;

        public MySqlConnection MyConectarBD() //Método: MyConectarBD()
        {

            try
            {
                cn.Open();
            }

            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao se conectar" + erro.Message;
            }
            return cn;
        }


        public MySqlConnection MyDesConectarBD()  //Método: MyDesConectarBD()
        {

            try
            {
                cn.Close();
            }

            catch (Exception erro)
            {
                msg = "Ocorreu um erro ao se Desconectar" + erro.Message;
            }
            return cn;
        }
    }
}