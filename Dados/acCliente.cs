using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Tcc.Areas.Funcionario.Models;
using Tcc.Models;

namespace Tcc.Dados
{
    public class acCliente
    {
        Conexao con = new Conexao();

        public void inserirCliente(modelCliente cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_insertCliente(@nomeCliente,@sobrenomeCliente,@rgCliente,@cpfCliente,@telefoneCliente,@celularCliente,@idEndereco,@idLogin,@idPlano)", con.MyConectarBD());

            cmd.Parameters.Add("@nomeCliente", MySqlDbType.VarChar).Value = cm.nomeCliente;
            cmd.Parameters.Add("@sobrenomeCliente", MySqlDbType.VarChar).Value = cm.sobrenomeCliente;
            cmd.Parameters.Add("@rgCliente", MySqlDbType.VarChar).Value = cm.rgCliente;
            cmd.Parameters.Add("@cpfCliente", MySqlDbType.VarChar).Value = cm.cpfCliente;
            cmd.Parameters.Add("@telefoneCliente", MySqlDbType.VarChar).Value = cm.telefoneCliente;
            cmd.Parameters.Add("@celularCliente", MySqlDbType.VarChar).Value = cm.celularCliente;
            cmd.Parameters.Add("@idEndereco", MySqlDbType.VarChar).Value = cm.idEndereco;
            cmd.Parameters.Add("@idLogin", MySqlDbType.VarChar).Value = cm.idLogin;
            cmd.Parameters.Add("@idPlano", MySqlDbType.VarChar).Value = cm.idPlano;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
        public void TestarCliente(modelCliente cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_testeCliente(@nomeCliente,@sobrenomeCliente,@rgCliente,@cpfCliente)", con.MyConectarBD());

            cmd.CommandType.Equals(CommandType.StoredProcedure);

            cmd.Parameters.AddWithValue("@nomeCliente", cm.nomeCliente);
            cmd.Parameters.AddWithValue("@sobrenomeCliente", cm.sobrenomeCliente);
            cmd.Parameters.AddWithValue("@rgCliente", cm.rgCliente);
            cmd.Parameters.AddWithValue("@cpfCliente", cm.cpfCliente);

            MySqlDataReader leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    cm.idCliente = Convert.ToInt32(leitor["idCliente"]);
                }
            }

            else
            {
                cm.idCliente = 0;
            }

            con.MyDesConectarBD();
        }

        public List<modelCliente> buscarCliente()
        {
            List<modelCliente> clienteList = new List<modelCliente>();
            MySqlCommand cmd = new MySqlCommand("call pcd_selectCliente();", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.MyDesConectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                clienteList.Add(
                    new modelCliente
                    {
                        idCliente = Convert.ToInt32(dr["idCliente"]),
                        nomeCliente = Convert.ToString(dr["nomeCliente"]),
                        sobrenomeCliente = Convert.ToString(dr["sobrenomeCliente"]),
                        rgCliente = Convert.ToString(dr["rgCliente"]),
                        cpfCliente = Convert.ToString(dr["cpfCliente"]),
                        telefoneCliente = Convert.ToString(dr["telefoneCliente"]),
                        celularCliente = Convert.ToString(dr["celularCliente"]),
                        idEndereco = Convert.ToInt32(dr["idEndereco"]),
                        nomeEndereco = Convert.ToString(dr["nomeEndereco"]),
                        logradouroEndereco = Convert.ToString(dr["logradouroEndereco"]),
                        numeroEndereco = Convert.ToString(dr["numeroEndereco"]),
                        complementoEndereco = Convert.ToString(dr["complementoEndereco"]),
                        cepEndereco = Convert.ToString(dr["cepEndereco"]),
                        bairroEndereco = Convert.ToString(dr["bairroEndereco"]),
                        cidadeEndereco = Convert.ToString(dr["cidadeEndereco"]),
                        siglaEstado = Convert.ToString(dr["siglaEstado"]),
                        idLogin = Convert.ToInt32(dr["idLogin"]),
                        email = Convert.ToString(dr["email"]),
                        senha = Convert.ToString(dr["senha"]),
                        idPlano = Convert.ToInt32(dr["idPlano"]),
                        nomePlano = Convert.ToString(dr["nomePlano"]),
                        corPlano = Convert.ToString(dr["corPlano"]),
                        imgPlano = Convert.ToString(dr["imgPlano"]),
                        tipoPlano = Convert.ToString(dr["tipoPlano"])
                    }
                    );
            }
            return clienteList;
        }

        public void atualizarCliente(modelCliente cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_updateCliente(@idCliente,@nomeCliente,@sobrenomeCliente,@rgCliente,@cpfCliente,@telefoneCliente,@celularCliente)", con.MyConectarBD());

            cmd.Parameters.Add("@idCliente", MySqlDbType.Int32).Value = cm.idCliente;
            cmd.Parameters.Add("@nomeCliente", MySqlDbType.VarChar).Value = cm.nomeCliente;
            cmd.Parameters.Add("@sobrenomeCliente", MySqlDbType.VarChar).Value = cm.sobrenomeCliente;
            cmd.Parameters.Add("@rgCliente", MySqlDbType.VarChar).Value = cm.rgCliente;
            cmd.Parameters.Add("@cpfCliente", MySqlDbType.VarChar).Value = cm.cpfCliente;
            cmd.Parameters.Add("@telefoneCliente", MySqlDbType.VarChar).Value = cm.telefoneCliente;
            cmd.Parameters.Add("@celularCliente", MySqlDbType.VarChar).Value = cm.celularCliente;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public void deletarCliente(int cod)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_deleteCliente(@idCliente)", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@idCliente", cod);
            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
    }
}