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
    public class VeterinarioController : Controller
    {
        acVeterinario acVeterinarioAcoes = new acVeterinario();
        modelVeterinario modVeterinario = new modelVeterinario();
        public void carregarClinica()
        {
            List<SelectListItem> clinicas = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost; Port=3306; DataBase=dbTcc; User=root; pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("call pcd_selectClinica()", con);
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
        public ActionResult CadVeterinario()
        {
            carregarClinica();
            return View();
        }

        [HttpPost]
        public ActionResult CadVeterinario(modelVeterinario cl)
        {
            carregarClinica();
            cl.idClinica = Convert.ToInt32(Request["clinicas"]);
            acVeterinarioAcoes.inserirVeterinario(cl);
            ViewBag.Message = "Cadastro realizado com sucesso!";
            return RedirectToAction(nameof(ListarVeterinario));
        }

        public ActionResult ListarVeterinario()
        {

            return View(acVeterinarioAcoes.buscarVeterinario());
        }
        public ActionResult EditarVeterinario(int id)
        {
            carregarClinica();
            return View(acVeterinarioAcoes.buscarVeterinario().Find(modelVeterinario => modelVeterinario.idVeterinario == id));
        }

        [HttpPost]
        public ActionResult EditarVeterinario(modelVeterinario cl)
        {
            carregarClinica();
            cl.idClinica = Convert.ToInt32(Request["clinicas"]);
            acVeterinarioAcoes.atualizarVeterinario(cl);
            ViewBag.Message = "Alteração realizada com sucesso!";
            return RedirectToAction(nameof(ListarVeterinario));
        }
        public ActionResult ExcluirVeterinario(int id)
        {
            acVeterinarioAcoes.deletarVeterinario(id);
            ViewBag.Message = "Exclusão realizada com sucesso!";
            return RedirectToAction(nameof(ListarVeterinario));
        }
    }
}