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
    public class acBeneficio
    {
        Conexao con = new Conexao();

        public void inserirBeneficio(modelBeneficio cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_insertBeneficio(@nomeBeneficio, @idPlano)", con.MyConectarBD());

            cmd.Parameters.Add("@nomeBeneficio", MySqlDbType.VarChar).Value = cm.nomeBeneficio;
            cmd.Parameters.Add("@idPlano", MySqlDbType.VarChar).Value = cm.idPlano;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public List<modelBeneficio> buscarBeneficio()
        {
            List<modelBeneficio> beneList = new List<modelBeneficio>();
            MySqlCommand cmd = new MySqlCommand("call pcd_selectBeneficio();", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.MyDesConectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                beneList.Add(
                    new modelBeneficio
                    {
                        idBeneficio = Convert.ToInt32(dr["idBeneficio"]),
                        nomeBeneficio = Convert.ToString(dr["nomeBeneficio"]),
                        nomePlano = Convert.ToString(dr["nomePlano"])
                    }
                    );
            }
            return beneList;
        }

        public List<modelBeneficio> buscarBeneficioPlano()
        {
            List<modelBeneficio> beneList = new List<modelBeneficio>();
            MySqlCommand cmd = new MySqlCommand("select * from tbBeneficio;", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.MyDesConectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                beneList.Add(
                    new modelBeneficio
                    {
                        idBeneficio = Convert.ToInt32(dr["idBeneficio"]),
                        nomeBeneficio = Convert.ToString(dr["nomeBeneficio"]),
                        idPlano = Convert.ToInt32(dr["idPlano"])
                    }
                    );
            }
            return beneList;
        }

        public void atualizarBeneficio(modelBeneficio cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_updateBeneficio(@idBeneficio, @nomeBeneficio," +
                " @idPlano)", con.MyConectarBD());

            cmd.Parameters.Add("@idBeneficio", MySqlDbType.Int32).Value = cm.idBeneficio;
            cmd.Parameters.Add("@nomeBeneficio", MySqlDbType.VarChar).Value = cm.nomeBeneficio;
            cmd.Parameters.Add("@idPlano", MySqlDbType.Int32).Value = cm.idPlano;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public void deletarBeneficio(int cod)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_deleteBeneficio(@idBeneficio)", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@idBeneficio", cod);
            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
    }
}