using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tcc.Areas.Funcionario.Dados;
using Tcc.Areas.Funcionario.Models;
using Tcc.Dados;
using Tcc.Models;

namespace Tcc.Areas.Funcionario.Controllers
{
    public class AtendimentoController : Controller
    {
        acAtendimento acAtendimentoAcoes = new acAtendimento();
        modelAtendimento modAtendimento = new modelAtendimento();

        public void carregarVeterinario()
        {
            List<SelectListItem> veterinarios = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost; Port=3306; DataBase=dbTcc; User=root; pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select idVeterinario, nomeVeterinario from tbVeterinario", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    veterinarios.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
            }

            ViewBag.veterinarios = new SelectList(veterinarios, "Value", "Text");
        }

        public void carregarClinica()
        {
            List<SelectListItem> clinicas = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost; Port=3306; DataBase=dbTcc; User=root; pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select idClinica, nomeClinica from tbClinica", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    clinicas.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
            }

            ViewBag.clinicas = new SelectList(clinicas, "Value", "Text");
        }

        public void carregarAnimal()
        {
            List<SelectListItem> animais = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost; Port=3306; DataBase=dbTcc; User=root; pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select idAnimal, nomeAnimal from tbAnimal", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    animais.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
            }

            ViewBag.animais = new SelectList(animais, "Value", "Text");
        }

        public void carregarStatus()
        {
            List<SelectListItem> status = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost; Port=3306; DataBase=dbTcc; User=root; pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select idStatus, nomeStatus from tbStatus", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    status.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
            }

            ViewBag.status = new SelectList(status, "Value", "Text");
        }

        public ActionResult ListarAtendimento()
        {
            return View(acAtendimentoAcoes.ListarAtendimentos());
        }

        public ActionResult CadAtendimento()
        {
            carregarVeterinario();
            carregarClinica();
            carregarAnimal();
            carregarStatus();
            return View();
        }

        [HttpPost]
        public ActionResult CadAtendimento(modelAtendimento cl)
        {
            carregarVeterinario();
            carregarClinica();
            carregarAnimal();
            carregarStatus();
            cl.idVeterinario = Convert.ToInt32(Request["veterinarios"]);
            cl.idClinica = Convert.ToInt32(Request["clinicas"]);
            cl.idAnimal = Convert.ToInt32(Request["animais"]);
            cl.idStatus = Convert.ToInt32(Request["status"]);
            acAtendimentoAcoes.inserirAtendimento(cl);
            ViewBag.Message = "Cadastro realizado com sucesso!";
            return RedirectToAction(nameof(ListarAtendimento));
        }

        public ActionResult EditarAtendimento(int id)
        {
            carregarVeterinario();
            carregarClinica();
            carregarAnimal();
            carregarStatus();
            return View(acAtendimentoAcoes.ListarAtendimentos().Find(modelAtendimento => modelAtendimento.idAtendimento == id));
        }

        [HttpPost]
        public ActionResult EditarAtendimento(modelAtendimento cl)
        {
            carregarVeterinario();
            carregarClinica();
            carregarAnimal();
            carregarStatus();
            cl.idVeterinario = Convert.ToInt32(Request["veterinarios"]);
            cl.idClinica = Convert.ToInt32(Request["clinicas"]);
            cl.idAnimal = Convert.ToInt32(Request["animais"]);
            cl.idStatus = Convert.ToInt32(Request["status"]);
            acAtendimentoAcoes.atualizarAtendimento(cl);
            ViewBag.Message = "Alteração realizada com sucesso!";
            return RedirectToAction(nameof(ListarAtendimento));
        }

        public ActionResult ExcluirAtendimento(int id)
        {
            acAtendimentoAcoes.deletarAtendimento(id);
            ViewBag.Message = "Exclusão realizada com sucesso!";
            return RedirectToAction(nameof(ListarAtendimento));
        }
    }
}