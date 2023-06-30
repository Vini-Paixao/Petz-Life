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
    public class acTipo
    {
        Conexao con = new Conexao();

        public void inserirTipo(modelTipo cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_insertTipo(@nomeTipo)", con.MyConectarBD());

            cmd.Parameters.Add("@nomeTipo", MySqlDbType.VarChar).Value = cm.nomeTipo;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public List<modelTipo> buscarTipo()
        {
            List<modelTipo> tipoList = new List<modelTipo>();
            MySqlCommand cmd = new MySqlCommand("call pcd_selectTipo();", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.MyDesConectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                tipoList.Add(
                    new modelTipo
                    {
                        idTipo = Convert.ToInt32(dr["idTipo"]),
                        nomeTipo = Convert.ToString(dr["nomeTipo"])
                    }
                    );
            }
            return tipoList;
        }

        public void atualizarTipo(modelTipo cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_updateTipo(@idTipo, @nomeTipo)", con.MyConectarBD());

            cmd.Parameters.Add("@idTipo", MySqlDbType.VarChar).Value = cm.idTipo;
            cmd.Parameters.Add("@nomeTipo", MySqlDbType.VarChar).Value = cm.nomeTipo;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public void deletarTipo(int cod)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_deleteTipo(@idTipo)", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@idTipo", cod);
            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
    }
}