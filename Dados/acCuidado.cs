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
    public class acCuidado
    {
        Conexao con = new Conexao();

        public void inserirCuidado(modelCuidado cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_insertCuidado(@descCuidado,@idAnimal)", con.MyConectarBD());

            cmd.Parameters.Add("@descCuidado", MySqlDbType.VarChar).Value = cm.descCuidado;
            cmd.Parameters.Add("@idAnimal", MySqlDbType.Int32).Value = cm.idAnimal;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public List<modelCuidado> buscarCuidado()
        {
            List<modelCuidado> cuidadoList = new List<modelCuidado>();
            MySqlCommand cmd = new MySqlCommand("call pcd_selectCuidado();", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.MyDesConectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                cuidadoList.Add(
                    new modelCuidado
                    {
                        idCuidado = Convert.ToInt32(dr["idCuidado"]),
                        descCuidado = Convert.ToString(dr["descCuidado"]),
                        idAnimal = Convert.ToInt32(dr["idAnimal"]),
                        nomeAnimal = Convert.ToString(dr["nomeAnimal"])
                    }
                    );
            }
            return cuidadoList;
        }

        public List<modelCuidado> buscarCuidadoPorId(int vAnimal)
        {
            List<modelCuidado> cuidadoList = new List<modelCuidado>();
            MySqlCommand cmd = new MySqlCommand("call pcd_selectCuidadoPorId(@_idAnimal);", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@_idAnimal", vAnimal);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.MyDesConectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                cuidadoList.Add(
                    new modelCuidado
                    {
                        idCuidado = Convert.ToInt32(dr["idCuidado"]),
                        descCuidado = Convert.ToString(dr["descCuidado"]),
                        idAnimal = Convert.ToInt32(dr["idAnimal"])
                    }
                    );
            }
            return cuidadoList;
        }

        public void atualizarCuidado(modelCuidado cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_updateCuidado(@idCuidado,@descCuidado,@idAnimal)", con.MyConectarBD());

            cmd.Parameters.Add("@idCuidado", MySqlDbType.Int32).Value = cm.idCuidado;
            cmd.Parameters.Add("@descCuidado", MySqlDbType.VarChar).Value = cm.descCuidado;
            cmd.Parameters.Add("@idAnimal", MySqlDbType.Int32).Value = cm.idAnimal;
            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public void deletarCuidado(int cod)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_deleteCuidado(@idCuidado)", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@idCuidado", cod);
            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
    }
}