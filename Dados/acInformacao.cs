using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Tcc.Models;

namespace Tcc.Dados
{
    public class acInformacao
    {
        Conexao con = new Conexao();

        public void inserirInformacao(modelInformacao cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_insertInformacao(@descInformacao,@idAnimal)", con.MyConectarBD());

            cmd.Parameters.Add("@descInformacao", MySqlDbType.VarChar).Value = cm.descInformacao;
            cmd.Parameters.Add("@idAnimal", MySqlDbType.Int32).Value = cm.idAnimal;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public List<modelInformacao> buscarInformacao()
        {
            List<modelInformacao> informacaoList = new List<modelInformacao>();
            MySqlCommand cmd = new MySqlCommand("call pcd_selectInformacao();", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.MyDesConectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                informacaoList.Add(
                    new modelInformacao
                    {
                        idInformacao = Convert.ToInt32(dr["idInformacao"]),
                        descInformacao = Convert.ToString(dr["descInformacao"]),
                        idAnimal = Convert.ToInt32(dr["idAnimal"]),
                        nomeAnimal = Convert.ToString(dr["nomeAnimal"])
                    }
                    );
            }
            return informacaoList;
        }

        public List<modelInformacao> buscarInformacaoPorId(int vAnimal)
        {
            List<modelInformacao> informacaoList = new List<modelInformacao>();
            MySqlCommand cmd = new MySqlCommand("call pcd_selectInformacaoPorId(@_idAnimal);", con.MyConectarBD());
            cmd.Parameters.AddWithValue("@_idAnimal", vAnimal);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.MyDesConectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                informacaoList.Add(
                    new modelInformacao
                    {
                        idInformacao = Convert.ToInt32(dr["idInformacao"]),
                        descInformacao = Convert.ToString(dr["descInformacao"]),
                        idAnimal = Convert.ToInt32(dr["idAnimal"])
                    }
                    );
            }
            return informacaoList;
        }

        public void atualizarInformacao(modelInformacao cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_updateInformacao(@idInformacao,@descInformacao,@idAnimal)", con.MyConectarBD());

            cmd.Parameters.Add("@idInformacao", MySqlDbType.Int32).Value = cm.idInformacao;
            cmd.Parameters.Add("@descInformacao", MySqlDbType.VarChar).Value = cm.descInformacao;
            cmd.Parameters.Add("@idAnimal", MySqlDbType.Int32).Value = cm.idAnimal;
            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public void deletarInformacao(int cod)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_deleteInformacao(@idInformacao)", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@idInformacao", cod);
            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
    }
}