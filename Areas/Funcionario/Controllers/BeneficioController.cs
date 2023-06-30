using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Web;
using System.Web.Mvc;
using Tcc.Areas.Funcionario.Dados;
using Tcc.Areas.Funcionario.Models;

namespace Tcc.Areas.Funcionario.Controllers
{
    public class BeneficioController : Controller
    {
        acBeneficio acBeneficioAcoes = new acBeneficio();
        modelBeneficio modBeneficio = new modelBeneficio();
        public void carregarPlano()
        {
            List<SelectListItem> planos = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost; Port=3306; DataBase=dbTcc; User=root; pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select idPlano, nomePlano from tbPlano", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    planos.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
            }

            ViewBag.planos = new SelectList(planos, "Value", "Text");
        }
        public ActionResult CadBeneficio()
        {
            carregarPlano();
            return View();
        }

        [HttpPost]
        public ActionResult CadBeneficio(modelBeneficio cl)
        {
            carregarPlano();
            cl.idPlano = Convert.ToInt32(Request["planos"]);
            acBeneficioAcoes.inserirBeneficio(cl);
            ViewBag.Message = "Cadastro realizado com sucesso!";
            return RedirectToAction(nameof(ListarBeneficio));
        }

        public ActionResult ListarBeneficio()
        {
            return View(acBeneficioAcoes.buscarBeneficio());
        }
        public ActionResult EditarBeneficio(int id)
        {
            carregarPlano();
            return View(acBeneficioAcoes.buscarBeneficio().Find(modelBeneficio => modelBeneficio.idBeneficio == id));
        }

        [HttpPost]
        public ActionResult EditarBeneficio(modelBeneficio cl)
        {
            carregarPlano();
            cl.idPlano = Convert.ToInt32(Request["planos"]);
            acBeneficioAcoes.atualizarBeneficio(cl);
            ViewBag.Message = "Alteração realizada com sucesso!";
            return RedirectToAction(nameof(ListarBeneficio));
        }
        public ActionResult ExcluirBeneficio(int id)
        {
            acBeneficioAcoes.deletarBeneficio(id);
            ViewBag.Message = "Exclusão realizada com sucesso!";
            return RedirectToAction(nameof(ListarBeneficio));
        }
    }
}