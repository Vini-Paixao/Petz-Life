using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Tcc.Areas.Funcionario.Models;
using Tcc.Dados;

namespace Tcc.Areas.Funcionario.Dados
{
    public class acClinica
    {
        Conexao con = new Conexao();

        public void inserirClinica(modelClinica cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_insertClinica(@nomeClinica,@telefoneClinica,@celularClinica,@emailClinica,@avaliacaoClinica,@horarioClinica,@idEndereco)", con.MyConectarBD());

            cmd.Parameters.Add("@nomeClinica", MySqlDbType.VarChar).Value = cm.nomeClinica;
            cmd.Parameters.Add("@telefoneClinica", MySqlDbType.VarChar).Value = cm.telefoneClinica;
            cmd.Parameters.Add("@celularClinica", MySqlDbType.VarChar).Value = cm.celularClinica;
            cmd.Parameters.Add("@emailClinica", MySqlDbType.VarChar).Value = cm.emailClinica;
            cmd.Parameters.Add("@avaliacaoClinica", MySqlDbType.VarChar).Value = cm.avaliacaoClinica;
            cmd.Parameters.Add("@horarioClinica", MySqlDbType.VarChar).Value = cm.horarioClinica;
            cmd.Parameters.Add("@idEndereco", MySqlDbType.VarChar).Value = cm.idEndereco;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public List<modelClinica> buscarClinica()
        {
            List<modelClinica> clinicaList = new List<modelClinica>();
            MySqlCommand cmd = new MySqlCommand("call pcd_selectClinica();", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.MyDesConectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                clinicaList.Add(
                    new modelClinica
                    {
                        idClinica = Convert.ToInt32(dr["idClinica"]),
                        nomeClinica = Convert.ToString(dr["nomeClinica"]),
                        telefoneClinica = Convert.ToString(dr["telefoneClinica"]),
                        celularClinica = Convert.ToString(dr["celularClinica"]),
                        emailClinica = Convert.ToString(dr["emailClinica"]),
                        avaliacaoClinica = Convert.ToString(dr["avaliacaoClinica"]),
                        horarioClinica = Convert.ToString(dr["horarioClinica"]),
                        idEndereco = Convert.ToString(dr["idEndereco"]),
                        nomeEndereco = Convert.ToString(dr["nomeEndereco"]),
                        logradouroEndereco = Convert.ToString(dr["logradouroEndereco"]),
                        numeroEndereco = Convert.ToString(dr["numeroEndereco"]),
                        cepEndereco = Convert.ToString(dr["cepEndereco"]),
                        bairroEndereco = Convert.ToString(dr["bairroEndereco"]),
                        cidadeEndereco = Convert.ToString(dr["cidadeEndereco"]),
                        siglaEstado = Convert.ToString(dr["siglaEstado"])
                    }
                    );
            }
            return clinicaList;
        }

        public void atualizarClinica(modelClinica cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_updateClinica(@idClinica,@nomeClinica,@telefoneClinica,@celularClinica,@emailClinica,@avaliacaoClinica,@horarioClinica,@idEndereco)", con.MyConectarBD());

            cmd.Parameters.Add("@idClinica", MySqlDbType.Int32).Value = cm.idClinica;
            cmd.Parameters.Add("@nomeClinica", MySqlDbType.VarChar).Value = cm.nomeClinica;
            cmd.Parameters.Add("@telefoneClinica", MySqlDbType.VarChar).Value = cm.telefoneClinica;
            cmd.Parameters.Add("@celularClinica", MySqlDbType.VarChar).Value = cm.celularClinica;
            cmd.Parameters.Add("@emailClinica", MySqlDbType.VarChar).Value = cm.emailClinica;
            cmd.Parameters.Add("@avaliacaoClinica", MySqlDbType.VarChar).Value = cm.avaliacaoClinica;
            cmd.Parameters.Add("@horarioClinica", MySqlDbType.VarChar).Value = cm.horarioClinica;
            cmd.Parameters.Add("@idEndereco", MySqlDbType.VarChar).Value = cm.idEndereco;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public void deletarClinica(int cod)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_deleteClinica(@idClinica)", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@idClinica", cod);
            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
    }
}