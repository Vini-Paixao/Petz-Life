using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Tcc.Models;

namespace Tcc.Dados
{
    public class acAtendimento
    {
        Conexao con = new Conexao();

        public void inserirAtendimento(modelAtendimento cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_insertAtendimento(@dataHoraAtendimento,@descricaoAtendimento,@idStatus,@idClinica,@idVeterinario,@idAnimal)", con.MyConectarBD());

            cmd.Parameters.Add("@dataHoraAtendimento", MySqlDbType.DateTime).Value = cm.dataHoraAtendimento;
            cmd.Parameters.Add("@descricaoAtendimento", MySqlDbType.VarChar).Value = cm.descricaoAtendimento;
            cmd.Parameters.Add("@idStatus", MySqlDbType.Int32).Value = cm.idStatus;
            cmd.Parameters.Add("@idClinica", MySqlDbType.Int32).Value = cm.idClinica;
            cmd.Parameters.Add("@idVeterinario", MySqlDbType.Int32).Value = cm.idVeterinario;
            cmd.Parameters.Add("@idAnimal", MySqlDbType.Int32).Value = cm.idAnimal;

            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public List<modelAtendimento> buscarAtendimento(int id)
        {
            List<modelAtendimento> AtendimentoList = new List<modelAtendimento>();
            MySqlCommand cmd = new MySqlCommand("call pcd_selectAtendimento(@idLogin);", con.MyConectarBD());
            cmd.CommandType.Equals(CommandType.StoredProcedure);
            cmd.Parameters.AddWithValue("@idLogin", id);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.MyDesConectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                AtendimentoList.Add(
                    new modelAtendimento
                    {
                        idAtendimento = Convert.ToInt32(dr["idAtendimento"]),
                        dataHoraAtendimento = Convert.ToDateTime(dr["dataHoraAtendimento"]),
                        descricaoAtendimento = Convert.ToString(dr["descricaoAtendimento"]),
                        idStatus = Convert.ToInt32(dr["idStatus"]),
                        nomeStatus = Convert.ToString(dr["nomeStatus"]),
                        idClinica = Convert.ToInt32(dr["idClinica"]),
                        nomeClinica = Convert.ToString(dr["nomeClinica"]),
                        idEndereco = Convert.ToInt32(dr["idEndereco"]),
                        logradouroEndereco = Convert.ToString(dr["logradouroEndereco"]),
                        numeroEndereco = Convert.ToString(dr["numeroEndereco"]),
                        cepEndereco = Convert.ToString(dr["cepEndereco"]),
                        bairroEndereco = Convert.ToString(dr["bairroEndereco"]),
                        cidadeEndereco = Convert.ToString(dr["cidadeEndereco"]),
                        siglaEstado = Convert.ToString(dr["siglaEstado"]),
                        idVeterinario = Convert.ToInt32(dr["idVeterinario"]),
                        nomeVeterinario = Convert.ToString(dr["nomeVeterinario"]),
                        especVeterinario = Convert.ToString(dr["especVeterinario"]),
                        idAnimal = Convert.ToInt32(dr["idAnimal"]),
                        nomeAnimal = Convert.ToString(dr["nomeAnimal"]),
                        idCliente = Convert.ToInt32(dr["idCliente"])
                    }
                    );
            }
            return AtendimentoList;
        }

        public List<modelAtendimento> ListarAtendimentos()
        {
            List<modelAtendimento> AtendimentoList = new List<modelAtendimento>();
            MySqlCommand cmd = new MySqlCommand("call pcd_selectAtendimentos();", con.MyConectarBD());
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.MyDesConectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                AtendimentoList.Add(
                    new modelAtendimento
                    {
                        idAtendimento = Convert.ToInt32(dr["idAtendimento"]),
                        dataHoraAtendimento = Convert.ToDateTime(dr["dataHoraAtendimento"]),
                        descricaoAtendimento = Convert.ToString(dr["descricaoAtendimento"]),
                        nomeStatus = Convert.ToString(dr["nomeStatus"]),
                        nomeClinica = Convert.ToString(dr["nomeClinica"]),
                        logradouroEndereco = Convert.ToString(dr["logradouroEndereco"]),
                        numeroEndereco = Convert.ToString(dr["numeroEndereco"]),
                        cepEndereco = Convert.ToString(dr["cepEndereco"]),
                        bairroEndereco = Convert.ToString(dr["bairroEndereco"]),
                        cidadeEndereco = Convert.ToString(dr["cidadeEndereco"]),
                        siglaEstado = Convert.ToString(dr["siglaEstado"]),
                        nomeVeterinario = Convert.ToString(dr["nomeVeterinario"]),
                        especVeterinario = Convert.ToString(dr["especVeterinario"]),
                        nomeAnimal = Convert.ToString(dr["nomeAnimal"]),
                        nomeCliente = Convert.ToString(dr["nomeCliente"])
                    }
                    );
            }
            return AtendimentoList;
        }

        public List<modelAtendimento> buscarAtendimentosAgendados(int id)
        {
            List<modelAtendimento> AtendimentoList = new List<modelAtendimento>();
            MySqlCommand cmd = new MySqlCommand("call pcd_selectAtendimentosAgendados(@idLogin);", con.MyConectarBD());
            cmd.CommandType.Equals(CommandType.StoredProcedure);
            cmd.Parameters.AddWithValue("@idLogin", id);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.MyDesConectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                AtendimentoList.Add(
                    new modelAtendimento
                    {
                        idAtendimento = Convert.ToInt32(dr["idAtendimento"]),
                        dataHoraAtendimento = Convert.ToDateTime(dr["dataHoraAtendimento"]),
                        descricaoAtendimento = Convert.ToString(dr["descricaoAtendimento"]),
                        idStatus = Convert.ToInt32(dr["idStatus"]),
                        nomeStatus = Convert.ToString(dr["nomeStatus"]),
                        idClinica = Convert.ToInt32(dr["idClinica"]),
                        nomeClinica = Convert.ToString(dr["nomeClinica"]),
                        idEndereco = Convert.ToInt32(dr["idEndereco"]),
                        logradouroEndereco = Convert.ToString(dr["logradouroEndereco"]),
                        numeroEndereco = Convert.ToString(dr["numeroEndereco"]),
                        cepEndereco = Convert.ToString(dr["cepEndereco"]),
                        bairroEndereco = Convert.ToString(dr["bairroEndereco"]),
                        cidadeEndereco = Convert.ToString(dr["cidadeEndereco"]),
                        siglaEstado = Convert.ToString(dr["siglaEstado"]),
                        idVeterinario = Convert.ToInt32(dr["idVeterinario"]),
                        nomeVeterinario = Convert.ToString(dr["nomeVeterinario"]),
                        especVeterinario = Convert.ToString(dr["especVeterinario"]),
                        idAnimal = Convert.ToInt32(dr["idAnimal"]),
                        nomeAnimal = Convert.ToString(dr["nomeAnimal"]),
                        idCliente = Convert.ToInt32(dr["idCliente"])
                    }
                    );
            }
            return AtendimentoList;
        }

        public List<modelAtendimento> buscarUltimosAtendimentos(int id)
        {
            List<modelAtendimento> AtendimentoList = new List<modelAtendimento>();
            MySqlCommand cmd = new MySqlCommand("call pcd_selectUltimosAtendimentos(@idLogin);", con.MyConectarBD());
            cmd.CommandType.Equals(CommandType.StoredProcedure);
            cmd.Parameters.AddWithValue("@idLogin", id);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.MyDesConectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                AtendimentoList.Add(
                    new modelAtendimento
                    {
                        idAtendimento = Convert.ToInt32(dr["idAtendimento"]),
                        dataHoraAtendimento = Convert.ToDateTime(dr["dataHoraAtendimento"]),
                        descricaoAtendimento = Convert.ToString(dr["descricaoAtendimento"]),
                        idStatus = Convert.ToInt32(dr["idStatus"]),
                        nomeStatus = Convert.ToString(dr["nomeStatus"]),
                        idClinica = Convert.ToInt32(dr["idClinica"]),
                        nomeClinica = Convert.ToString(dr["nomeClinica"]),
                        idEndereco = Convert.ToInt32(dr["idEndereco"]),
                        logradouroEndereco = Convert.ToString(dr["logradouroEndereco"]),
                        numeroEndereco = Convert.ToString(dr["numeroEndereco"]),
                        cepEndereco = Convert.ToString(dr["cepEndereco"]),
                        bairroEndereco = Convert.ToString(dr["bairroEndereco"]),
                        cidadeEndereco = Convert.ToString(dr["cidadeEndereco"]),
                        siglaEstado = Convert.ToString(dr["siglaEstado"]),
                        idVeterinario = Convert.ToInt32(dr["idVeterinario"]),
                        nomeVeterinario = Convert.ToString(dr["nomeVeterinario"]),
                        especVeterinario = Convert.ToString(dr["especVeterinario"]),
                        idAnimal = Convert.ToInt32(dr["idAnimal"]),
                        nomeAnimal = Convert.ToString(dr["nomeAnimal"]),
                        idCliente = Convert.ToInt32(dr["idCliente"])
                    }
                    );
            }
            return AtendimentoList;
        }

        public List<modelAtendimento> listarVeterinario(string espec)
        {
            List<modelAtendimento> VeterinarioList = new List<modelAtendimento>();
            MySqlCommand cmd = new MySqlCommand("call pcd_listarVeterinario(@especVeterinario);", con.MyConectarBD());
            cmd.CommandType.Equals(CommandType.StoredProcedure);
            cmd.Parameters.AddWithValue("@especVeterinario", espec);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.MyDesConectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                VeterinarioList.Add(
                    new modelAtendimento
                    {
                        idVeterinario = Convert.ToInt32(dr["idVeterinario"]),
                        nomeVeterinario = Convert.ToString(dr["nomeVeterinario"]),
                        especVeterinario = Convert.ToString(dr["especVeterinario"]),
                        idClinica = Convert.ToInt32(dr["idClinica"]),
                        nomeClinica = Convert.ToString(dr["nomeClinica"]),
                        idEndereco = Convert.ToInt32(dr["idEndereco"]),
                        logradouroEndereco = Convert.ToString(dr["logradouroEndereco"]),
                        numeroEndereco = Convert.ToString(dr["numeroEndereco"]),
                        cepEndereco = Convert.ToString(dr["cepEndereco"]),
                        bairroEndereco = Convert.ToString(dr["bairroEndereco"]),
                        cidadeEndereco = Convert.ToString(dr["cidadeEndereco"]),
                        siglaEstado = Convert.ToString(dr["siglaEstado"])
                    }
                    );
            }
            return VeterinarioList;
        }

        public List<modelAtendimento> listarEspecialidade()
        {
            List<modelAtendimento> EspecialidadeList = new List<modelAtendimento>();
            MySqlCommand cmd = new MySqlCommand("call pcd_listarEspecialidade();", con.MyConectarBD());

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.MyDesConectarBD();

            foreach (DataRow dr in dt.Rows)
            {
                EspecialidadeList.Add(
                    new modelAtendimento
                    {
                        especVeterinario = Convert.ToString(dr["especVeterinario"])
                    }
                    );
            }
            return EspecialidadeList;
        }

        public void atualizarAtendimento(modelAtendimento cm)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_updateAtendimento(@idAtendimento,@dataHoraAtendimento,@descricaoAtendimento,@idStatus,@idClinica,@idVeterinario,@idAnimal)", con.MyConectarBD());

            cmd.Parameters.Add("@idAtendimento", MySqlDbType.Int32).Value = cm.idAtendimento;
            cmd.Parameters.Add("@dataHoraAtendimento", MySqlDbType.DateTime).Value = cm.dataHoraAtendimento;
            cmd.Parameters.Add("@descricaoAtendimento", MySqlDbType.VarChar).Value = cm.descricaoAtendimento;
            cmd.Parameters.Add("@idStatus", MySqlDbType.Int32).Value = cm.idStatus;
            cmd.Parameters.Add("@idClinica", MySqlDbType.Int32).Value = cm.idClinica;
            cmd.Parameters.Add("@idVeterinario", MySqlDbType.Int32).Value = cm.idVeterinario;
            cmd.Parameters.Add("@idAnimal", MySqlDbType.Int32).Value = cm.idAnimal;
            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }

        public void deletarAtendimento(int cod)
        {
            MySqlCommand cmd = new MySqlCommand("call pcd_deleteAtendimento(@idAtendimento)", con.MyConectarBD());

            cmd.Parameters.AddWithValue("@idAtendimento", cod);
            cmd.ExecuteNonQuery();
            con.MyDesConectarBD();
        }
    }
}