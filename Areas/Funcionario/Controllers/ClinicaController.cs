using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tcc.Areas.Funcionario.Dados;
using Tcc.Areas.Funcionario.Models;

namespace Tcc.Areas.Funcionario.Controllers
{
    public class ClinicaController : Controller
    {
        acClinica acClinicaAcoes = new acClinica();
        modelClinica modClinica = new modelClinica();

        public void carregarEndereco()
        {
            List<SelectListItem> enderecos = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost; Port=3306; DataBase=dbTcc; User=root; pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select idEndereco, nomeEndereco from tbEndereco", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    enderecos.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
            }

            ViewBag.enderecos = new SelectList(enderecos, "Value", "Text");
        }

        public ActionResult ListarClinica()
        {
            return View(acClinicaAcoes.buscarClinica());
        }

        public ActionResult CadClinica()
        {
            carregarEndereco();
            return View();
        }
        [HttpPost]
        public ActionResult CadClinica(modelClinica cl)
        {
            carregarEndereco();
            cl.idEndereco = Request["enderecos"];
            acClinicaAcoes.inserirClinica(cl);
            ViewBag.Message = "Cadastro realizado com sucesso!";
            return RedirectToAction(nameof(ListarClinica));
        }

        public ActionResult EditarClinica(int id)
        {
            carregarEndereco();
            return View(acClinicaAcoes.buscarClinica().Find(modelClinica => modelClinica.idClinica == id));
        }
        [HttpPost]
        public ActionResult EditarClinica(modelClinica cl)
        {
            carregarEndereco();
            cl.idEndereco = Request["enderecos"];
            acClinicaAcoes.atualizarClinica(cl);
            ViewBag.Message = "Alteração realizada com sucesso!";
            return RedirectToAction(nameof(ListarClinica));
        }

        public ActionResult ExcluirClinica(int id)
        {
            acClinicaAcoes.deletarClinica(id);
            ViewBag.Message = "Exclusão realizada com sucesso!";
            return RedirectToAction(nameof(ListarClinica));
        }
    }
}