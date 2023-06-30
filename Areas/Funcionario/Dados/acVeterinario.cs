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
    public class acVeterinario
    {
        Conexao con = new Conexao();

        public void inserirVeterinario(modelVeterinario cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_insertVeterinario(@nomeVeterinario, @especVeterinario, @telefoneVeterinario, @emailVeterinario, @idClinica)", con.MyConectarBD());

            cmd.Parameters.Add("@nomeVeterinario", MySqlDbType.VarChar).Value = cm.nomeVeterinario;
            cmd.Parameters.Add("@especVeterinario", MySqlDbType.VarChar).Value = cm.especVeterinario;
            cmd.Parameters.Add("@telefoneVeterinario", MySqlDbType.VarChar).Value = cm.telefoneVeterinario;
            cmd.Parameters.Add("@emailVeterinario", MySqlDbType.VarChar).Value = cm.emailVeterinario;
            cmd.Parameters.Add("@idClinica", MySqlDbType.Int32).Value = cm.idClinica;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public List<modelVeterinario> buscarVeterinario()
        {
            List<modelVeterinario> veteList = new List<modelVeterinario>();
            MySqlCommand cmd = new MySqlCommand("call pcd_selectVeterinario();", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.MyDesConectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                veteList.Add(
                    new modelVeterinario
                    {
                        idVeterinario = Convert.ToInt32(dr["idVeterinario"]),
                        nomeVeterinario = Convert.ToString(dr["nomeVeterinario"]),
                        especVeterinario = Convert.ToString(dr["especVeterinario"]),
                        telefoneVeterinario = Convert.ToString(dr["telefoneVeterinario"]),
                        emailVeterinario = Convert.ToString(dr["emailVeterinario"]),
                        nomeClinica = Convert.ToString(dr["nomeClinica"])
                    }
                    );
            }
            return veteList;
        }

        public void atualizarVeterinario(modelVeterinario cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_updateVeterinario(@idVeterinario, @nomeVeterinario, @especVeterinario, @telefoneVeterinario, @emailVeterinario, @idClinica)", con.MyConectarBD());

            cmd.Parameters.Add("@idVeterinario", MySqlDbType.Int32).Value = cm.idVeterinario;
            cmd.Parameters.Add("@nomeVeterinario", MySqlDbType.VarChar).Value = cm.nomeVeterinario;
            cmd.Parameters.Add("@especVeterinario", MySqlDbType.VarChar).Value = cm.especVeterinario;
            cmd.Parameters.Add("@telefoneVeterinario", MySqlDbType.VarChar).Value = cm.telefoneVeterinario;
            cmd.Parameters.Add("@emailVeterinario", MySqlDbType.VarChar).Value = cm.emailVeterinario;
            cmd.Parameters.Add("@idClinica", MySqlDbType.Int32).Value = cm.idClinica;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public void deletarVeterinario(int cod)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_deleteVeterinario(@idVeterinario)", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@idVeterinario", cod);
            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
    }
}