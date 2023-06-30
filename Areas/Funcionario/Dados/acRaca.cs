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
    public class acRaca
    {
        Conexao con = new Conexao();

        public void inserirRaca(modelRaca cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_insertRaca(@nomeRaca, @idTipo)", con.MyConectarBD());

            cmd.Parameters.Add("@nomeRaca", MySqlDbType.VarChar).Value = cm.nomeRaca;
            cmd.Parameters.Add("@idTipo", MySqlDbType.VarChar).Value = cm.idTipo;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public List<modelRaca> buscarRaca()
        {
            List<modelRaca> racaList = new List<modelRaca>();
            MySqlCommand cmd = new MySqlCommand("call pcd_selectRaca();", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.MyDesConectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                racaList.Add(
                    new modelRaca
                    {
                        idRaca = Convert.ToInt32(dr["idRaca"]),
                        nomeRaca = Convert.ToString(dr["nomeRaca"]),
                        nomeTipo = Convert.ToString(dr["nomeTipo"])
                    }
                    );
            }
            return racaList;
        }

        public void atualizarRaca(modelRaca cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_updateRaca(@idRaca, @nomeRaca, @idTipo)", con.MyConectarBD());

            cmd.Parameters.Add("@idRaca", MySqlDbType.Int32).Value = cm.idRaca;
            cmd.Parameters.Add("@nomeRaca", MySqlDbType.VarChar).Value = cm.nomeRaca;
            cmd.Parameters.Add("@idTipo", MySqlDbType.VarChar).Value = cm.idTipo;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public void deletarRaca(int cod)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_deleteRaca(@idRaca)", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@idRaca", cod);
            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
    }
}