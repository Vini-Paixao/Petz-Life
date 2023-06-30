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
    public class RacaController : Controller
    {
        acRaca acRacaAcoes = new acRaca();
        modelRaca modRaca = new modelRaca();
        public void carregarTipo()
        {
            List<SelectListItem> tipos = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost; Port=3306; DataBase=dbTcc; User=root; pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("call pcd_selectTipo()", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    tipos.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
            }

            ViewBag.tipos = new SelectList(tipos, "Value", "Text");
        }
        public ActionResult CadRaca()
        {
            carregarTipo();
            return View();
        }

        [HttpPost]
        public ActionResult CadRaca(modelRaca cl)
        {
            carregarTipo();
            cl.idTipo = Request["tipos"];
            acRacaAcoes.inserirRaca(cl);
            ViewBag.Message = "Cadastro realizado com sucesso!";
            return RedirectToAction(nameof(ListarRaca));
        }

        public ActionResult ListarRaca()
        {

            return View(acRacaAcoes.buscarRaca());
        }
        public ActionResult EditarRaca(int id)
        {
            carregarTipo();
            return View(acRacaAcoes.buscarRaca().Find(modelRaca => modelRaca.idRaca == id));
        }

        [HttpPost]
        public ActionResult EditarRaca(modelRaca cl)
        {
            carregarTipo();
            cl.idTipo = Request["tipos"];
            acRacaAcoes.atualizarRaca(cl);
            ViewBag.Message = "Alteração realizada com sucesso!";
            return RedirectToAction(nameof(ListarRaca));
        }
        public ActionResult ExcluirRaca(int id)
        {
            acRacaAcoes.deletarRaca(id);
            ViewBag.Message = "Exclusão realizada com sucesso!";
            return RedirectToAction(nameof(ListarRaca));
        }
    }
}