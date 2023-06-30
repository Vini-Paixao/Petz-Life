using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Tcc.Models;

namespace Tcc.Dados
{
    public class acLogin
    {
        Conexao con = new Conexao();

        public void TestarUsuario(modelLogin user)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_testeLogin(@email, @senha)", con.MyConectarBD());

            cmd.CommandType.Equals(CommandType.StoredProcedure);

            cmd.Parameters.AddWithValue("@email", user.email);
            cmd.Parameters.AddWithValue("@senha", user.senha);

            MySqlDataReader leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    user.idLogin = Convert.ToInt32(leitor["idLogin"]);
                    user.usuario = Convert.ToString(leitor["usuario"]);
                    user.email = Convert.ToString(leitor["email"]);
                    user.senha = Convert.ToString(leitor["senha"]);
                    user.tipo = Convert.ToString(leitor["tipo"]);
                }
            }

            else
            {
                user.usuario = null;
                user.email = null;
                user.senha = null;
                user.tipo = null;
            }

            con.MyDesConectarBD();
        }
        public string TestarEmail(string _email)
        {

            MySqlCommand cmd = new MySqlCommand("call pcd_testeEmail(@email)", con.MyConectarBD());

            cmd.CommandType.Equals(CommandType.StoredProcedure);

            cmd.Parameters.AddWithValue("@email", _email);

            string Email = (string)cmd.ExecuteScalar();
            con.MyDesConectarBD();

            if (Email == null)
            {
                Email = "";
            }
            return Email;
        }

        public List<modelLogin> buscarLogin()
        {
            List<modelLogin> loginList = new List<modelLogin>();
            MySqlCommand cmd = new MySqlCommand("call pcd_selectLogin();", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.MyDesConectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                loginList.Add(
                    new modelLogin
                    {
                        idLogin = Convert.ToInt32(dr["idLogin"]),
                        usuario = Convert.ToString(dr["usuario"]),
                        email = Convert.ToString(dr["email"]),
                        senha = Convert.ToString(dr["senha"]),
                    }
                    );
            }
            return loginList;
        }

        public void inserirLoginCliente(modelLogin cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_insertLoginCliente(@usuario,@email,@senha)", con.MyConectarBD());

            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = cm.usuario;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = cm.email;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = cm.senha;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public void atualizarLoginCliente(modelLogin cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_updateLoginCliente(@idLogin,@usuario,@email,@senha)", con.MyConectarBD());

            cmd.Parameters.Add("@idLogin", MySqlDbType.Int32).Value = cm.idLogin;
            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = cm.usuario;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = cm.email;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = cm.senha;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public void deletarLoginCliente(int cod)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_deleteLogin(@idLogin)", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@idLogin", cod);

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
    }
}