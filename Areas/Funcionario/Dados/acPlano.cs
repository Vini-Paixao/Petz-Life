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
    public class acPlano
    {
        Conexao con = new Conexao();

        public void inserirPlano(modelPlano cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_insertPlano(@nomePlano, @tagPlano," +
                " @valorPlano, @tipoPlano, @corPlano, @imgPlano, @descPlano)", con.MyConectarBD());

            cmd.Parameters.Add("@nomePlano", MySqlDbType.VarChar).Value = cm.nomePlano;
            cmd.Parameters.Add("@tagPlano", MySqlDbType.VarChar).Value = cm.tagPlano;
            cmd.Parameters.Add("@valorPlano", MySqlDbType.VarChar).Value = cm.valorPlano;
            cmd.Parameters.Add("@tipoPlano", MySqlDbType.VarChar).Value = cm.tipoPlano;
            cmd.Parameters.Add("@corPlano", MySqlDbType.VarChar).Value = cm.corPlano;
            cmd.Parameters.Add("@imgPlano", MySqlDbType.VarChar).Value = cm.imgPlano;
            cmd.Parameters.Add("@descPlano", MySqlDbType.VarChar).Value = cm.descPlano;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public List<modelPlano> buscarPlano()
        {
            List<modelPlano> planoList = new List<modelPlano>();
            MySqlCommand cmd = new MySqlCommand("call pcd_selectPlano();", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.MyDesConectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                planoList.Add(
                    new modelPlano
                    {
                        idPlano = Convert.ToInt32(dr["idPlano"]),
                        nomePlano = Convert.ToString(dr["nomePlano"]),
                        tagPlano = Convert.ToString(dr["tagPlano"]),
                        valorPlano = Convert.ToString(dr["valorPlano"]),
                        tipoPlano = Convert.ToString(dr["tipoPlano"]),
                        corPlano = Convert.ToString(dr["corPlano"]),
                        imgPlano = Convert.ToString(dr["imgPlano"]),
                        descPlano = Convert.ToString(dr["descPlano"])
                    }
                    );
            }
            return planoList;
        }

        public List<modelPlano> buscarPlanoPorTipo()
        {
            List<modelPlano> planosLista = new List<modelPlano>();
            MySqlCommand cmd = new MySqlCommand("call pcd_selectPlanoPorTipo();", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.MyDesConectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                planosLista.Add(
                    new modelPlano
                    {
                        idPlano = Convert.ToInt32(dr["idPlano"]),
                        nomePlano = Convert.ToString(dr["nomePlano"]),
                        tagPlano = Convert.ToString(dr["tagPlano"]),
                        valorPlano = Convert.ToString(dr["valorPlano"]),
                        corPlano = Convert.ToString(dr["corPlano"]),
                        imgPlano = Convert.ToString(dr["imgPlano"])
                    }
                    );
            }
            return planosLista;
        }

        public void atualizarPlano(modelPlano cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_updatePlano(@idPlano, @nomePlano," +
                " @tagPlano, @valorPlano, @tipoPlano, @corPlano, @imgPlano, @descPlano)", con.MyConectarBD());

            cmd.Parameters.Add("@idPlano", MySqlDbType.VarChar).Value = cm.idPlano;
            cmd.Parameters.Add("@nomePlano", MySqlDbType.VarChar).Value = cm.nomePlano;
            cmd.Parameters.Add("@tagPlano", MySqlDbType.VarChar).Value = cm.tagPlano;
            cmd.Parameters.Add("@valorPlano", MySqlDbType.VarChar).Value = cm.valorPlano;
            cmd.Parameters.Add("@tipoPlano", MySqlDbType.VarChar).Value = cm.tipoPlano;
            cmd.Parameters.Add("@corPlano", MySqlDbType.VarChar).Value = cm.corPlano;
            cmd.Parameters.Add("@imgPlano", MySqlDbType.VarChar).Value = cm.imgPlano;
            cmd.Parameters.Add("@descPlano", MySqlDbType.VarChar).Value = cm.descPlano;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public void deletarPlano(int cod)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_deletePlano(@idPlano)", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@idPlano", cod);
            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
    }
}