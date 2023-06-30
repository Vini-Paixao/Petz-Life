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
    public class acFormaPagamento
    {
        Conexao con = new Conexao();

        public void inserirFormaPagamento(modelFormaPagamento cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_insertFormaPagamento(@nomeFormaPagamento)", con.MyConectarBD());

            cmd.Parameters.Add("@nomeFormaPagamento", MySqlDbType.VarChar).Value = cm.nomeFormaPagamento;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public List<modelFormaPagamento> buscarFormaPagamento()
        {
            List<modelFormaPagamento> formPagList = new List<modelFormaPagamento>();
            MySqlCommand cmd = new MySqlCommand("call pcd_selectFormaPagamento();", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.MyDesConectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                formPagList.Add(
                    new modelFormaPagamento
                    {
                        idFormaPagamento = Convert.ToInt32(dr["idFormaPagamento"]),
                        nomeFormaPagamento = Convert.ToString(dr["nomeFormaPagamento"])
                    }
                    );
            }
            return formPagList;
        }

        public void atualizarFormaPagamento(modelFormaPagamento cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_updateFormaPagamento(@idFormaPagamento, @nomeFormaPagamento)", con.MyConectarBD());

            cmd.Parameters.Add("@idFormaPagamento", MySqlDbType.VarChar).Value = cm.idFormaPagamento;
            cmd.Parameters.Add("@nomeFormaPagamento", MySqlDbType.VarChar).Value = cm.nomeFormaPagamento;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public void deletarFormaPagamento(int cod)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_deleteFormaPagamento(@idFormaPagamento)", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@idFormaPagamento", cod);
            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
    }
}