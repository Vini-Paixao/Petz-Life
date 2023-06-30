using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Tcc.Models;

namespace Tcc.Dados
{
    public class acAnimal
    {
        Conexao con = new Conexao();

        public void inserirAnimal(modelAnimal cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_insertAnimal(@nomeAnimal,@apelidoAnimal,@idadeAnimal,@imgAnimal,@idRaca,@idCliente)", con.MyConectarBD());

            cmd.Parameters.Add("@nomeAnimal", MySqlDbType.VarChar).Value = cm.nomeAnimal;
            cmd.Parameters.Add("@apelidoAnimal", MySqlDbType.VarChar).Value = cm.apelidoAnimal;
            cmd.Parameters.Add("@idadeAnimal", MySqlDbType.Int32).Value = cm.idadeAnimal;
            cmd.Parameters.Add("@imgAnimal", MySqlDbType.VarChar).Value = cm.imgAnimal;
            cmd.Parameters.Add("@idRaca", MySqlDbType.Int32).Value = cm.idRaca;
            cmd.Parameters.Add("@idCliente", MySqlDbType.Int32).Value = cm.idCliente;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public List<modelAnimal> buscarAnimal()
        {
            List<modelAnimal> animalList = new List<modelAnimal>();
            MySqlCommand cmd = new MySqlCommand("call pcd_selectAnimal();", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.MyDesConectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                animalList.Add(
                    new modelAnimal
                    {
                        idAnimal = Convert.ToInt32(dr["idAnimal"]),
                        nomeAnimal = Convert.ToString(dr["nomeAnimal"]),
                        apelidoAnimal = Convert.ToString(dr["apelidoAnimal"]),
                        idadeAnimal = Convert.ToInt32(dr["idadeAnimal"]),
                        imgAnimal = Convert.ToString(dr["imgAnimal"]),
                        idRaca = Convert.ToInt32(dr["idRaca"]),
                        nomeRaca = Convert.ToString(dr["nomeRaca"]),
                        idTipo = Convert.ToInt32(dr["idTipo"]),
                        nomeTipo = Convert.ToString(dr["nomeTipo"]),
                        idCliente = Convert.ToInt32(dr["idCliente"]),
                        idLogin = Convert.ToInt32(dr["idLogin"])
                    }
                    );
            }
            return animalList;
        }

        public int buscarId(int vLogin)
        {
            using (var connection = con.MyConectarBD())
            {
                MySqlCommand cmd = new MySqlCommand("call pcd_selectClienteId(@vlogin)", connection);
                cmd.Parameters.AddWithValue("@vlogin", vLogin);
                int id = (int)cmd.ExecuteScalar();
                con.MyDesConectarBD();
                return id;
            }
        }

        public void atualizarAnimal(modelAnimal cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_updateAnimal(@idAnimal,@nomeAnimal,@apelidoAnimal,@idadeAnimal,@imgAnimal,@idRaca)", con.MyConectarBD());

            cmd.Parameters.Add("@idAnimal", MySqlDbType.Int32).Value = cm.idAnimal;
            cmd.Parameters.Add("@nomeAnimal", MySqlDbType.VarChar).Value = cm.nomeAnimal;
            cmd.Parameters.Add("@apelidoAnimal", MySqlDbType.VarChar).Value = cm.apelidoAnimal;
            cmd.Parameters.Add("@idadeAnimal", MySqlDbType.VarChar).Value = cm.idadeAnimal;
            cmd.Parameters.Add("@imgAnimal", MySqlDbType.VarChar).Value = cm.imgAnimal;
            cmd.Parameters.Add("@idRaca", MySqlDbType.Int32).Value = cm.idRaca;
            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public void deletarAnimal(int cod)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_deleteAnimal(@idAnimal)", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@idAnimal", cod);
            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
    }
}