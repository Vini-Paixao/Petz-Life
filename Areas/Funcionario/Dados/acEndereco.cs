using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Tcc.Areas.Funcionario.Models;
using Tcc.Dados;
using Tcc.Models;

namespace Tcc.Areas.Funcionario.Dados
{
    public class acEndereco
    {
        Conexao con = new Conexao();

        public void inserirEndereco(modelEndereco cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_insertEndereco(@nomeEndereco,@logradouroEndereco,@numeroEndereco,@complementoEndereco,@cepEndereco,@bairroEndereco,@cidadeEndereco,@siglaEstado)", con.MyConectarBD());

            cmd.Parameters.Add("@nomeEndereco", MySqlDbType.VarChar).Value = cm.nomeEndereco;
            cmd.Parameters.Add("@logradouroEndereco", MySqlDbType.VarChar).Value = cm.logradouroEndereco;
            cmd.Parameters.Add("@numeroEndereco", MySqlDbType.VarChar).Value = cm.numeroEndereco;
            cmd.Parameters.Add("@complementoEndereco", MySqlDbType.VarChar).Value = cm.complementoEndereco;
            cmd.Parameters.Add("@cepEndereco", MySqlDbType.VarChar).Value = cm.cepEndereco;
            cmd.Parameters.Add("@bairroEndereco", MySqlDbType.VarChar).Value = cm.bairroEndereco;
            cmd.Parameters.Add("@cidadeEndereco", MySqlDbType.VarChar).Value = cm.cidadeEndereco;
            cmd.Parameters.Add("@siglaEstado", MySqlDbType.VarChar).Value = cm.siglaEstado;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
        public void TestarEndereco(modelEndereco modelEnde)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_testeEndereco(@nomeEndereco,@logradouroEndereco,@numeroEndereco,@complementoEndereco)", con.MyConectarBD());

            cmd.CommandType.Equals(CommandType.StoredProcedure);

            cmd.Parameters.AddWithValue("@nomeEndereco", modelEnde.nomeEndereco);
            cmd.Parameters.AddWithValue("@logradouroEndereco", modelEnde.logradouroEndereco);
            cmd.Parameters.AddWithValue("@numeroEndereco", modelEnde.numeroEndereco);
            cmd.Parameters.AddWithValue("@complementoEndereco", modelEnde.complementoEndereco);

            MySqlDataReader leitor = cmd.ExecuteReader();

            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    modelEnde.idEndereco = Convert.ToInt32(leitor["idEndereco"]);
                }
            }

            else
            {
                modelEnde.idEndereco = 0;
            }

            con.MyDesConectarBD();
        }
        public List<modelEndereco> buscarEndereco()
        {
            List<modelEndereco> enderecoList = new List<modelEndereco>();
            MySqlCommand cmd = new MySqlCommand("call pcd_selectEndereco();", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.MyDesConectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                enderecoList.Add(
                    new modelEndereco
                    {
                        idEndereco = Convert.ToInt32(dr["idEndereco"]),
                        nomeEndereco = Convert.ToString(dr["nomeEndereco"]),
                        logradouroEndereco = Convert.ToString(dr["logradouroEndereco"]),
                        numeroEndereco = Convert.ToString(dr["numeroEndereco"]),
                        complementoEndereco = Convert.ToString(dr["complementoEndereco"]),
                        cepEndereco = Convert.ToString(dr["cepEndereco"]),
                        bairroEndereco = Convert.ToString(dr["bairroEndereco"]),
                        cidadeEndereco = Convert.ToString(dr["cidadeEndereco"]),
                        siglaEstado = Convert.ToString(dr["siglaEstado"]),
                        nomeEstado = Convert.ToString(dr["nomeEstado"])
                    }
                    );
            }
            return enderecoList;
        }

        public void atualizarEndereco(modelEndereco cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_updateEndereco(@idEndereco,@nomeEndereco,@logradouroEndereco,@numeroEndereco,@complementoEndereco,@cepEndereco,@bairroEndereco,@cidadeEndereco,@siglaEstado)", con.MyConectarBD());

            cmd.Parameters.Add("@idEndereco", MySqlDbType.Int32).Value = cm.idEndereco;
            cmd.Parameters.Add("@nomeEndereco", MySqlDbType.VarChar).Value = cm.nomeEndereco;
            cmd.Parameters.Add("@logradouroEndereco", MySqlDbType.VarChar).Value = cm.logradouroEndereco;
            cmd.Parameters.Add("@numeroEndereco", MySqlDbType.VarChar).Value = cm.numeroEndereco;
            cmd.Parameters.Add("@complementoEndereco", MySqlDbType.VarChar).Value = cm.complementoEndereco;
            cmd.Parameters.Add("@cepEndereco", MySqlDbType.VarChar).Value = cm.cepEndereco;
            cmd.Parameters.Add("@bairroEndereco", MySqlDbType.VarChar).Value = cm.bairroEndereco;
            cmd.Parameters.Add("@cidadeEndereco", MySqlDbType.VarChar).Value = cm.cidadeEndereco;
            cmd.Parameters.Add("@siglaEstado", MySqlDbType.VarChar).Value = cm.siglaEstado;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public void deletarEndereco(int cod)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_deleteEndereco(@idEndereco)", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@idEndereco", cod);
            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
    }
}