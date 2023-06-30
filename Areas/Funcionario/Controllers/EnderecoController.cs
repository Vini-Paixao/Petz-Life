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
    public class EnderecoController : Controller
    {
        acEndereco acEnderecoAcoes = new acEndereco();
        modelEndereco modEndereco = new modelEndereco();
        public void carregarEstado()
        {
            List<SelectListItem> estados = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost; Port=3306; DataBase=dbTcc; User=root; pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbEstado", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    estados.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
            }

            ViewBag.estados = new SelectList(estados, "Value", "Text");
        }

        public ActionResult ListarEnderecoPorId(int id)
        {
            carregarEstado();
            return View(acEnderecoAcoes.buscarEndereco().Find(modelEndereco => modelEndereco.idEndereco == id));
        }

        public ActionResult CadEndereco()
        {
            carregarEstado();
            return View();
        }

        [HttpPost]
        public ActionResult CadEndereco(modelEndereco cl)
        {
            carregarEstado();
            cl.siglaEstado = Request["estados"];
            acEnderecoAcoes.inserirEndereco(cl);
            ViewBag.Message = "Cadastro realizado com sucesso!";
            return RedirectToAction("CadClinica","Clinica");
        }

        public ActionResult EditarEndereco(int id)
        {
            carregarEstado();
            return View(acEnderecoAcoes.buscarEndereco().Find(modelEndereco => modelEndereco.idEndereco == id));
        }

        [HttpPost]
        public ActionResult EditarEndereco(modelEndereco cl)
        {
            carregarEstado();
            cl.siglaEstado = Request["estados"];
            acEnderecoAcoes.atualizarEndereco(cl);
            ViewBag.Message = "Alteração realizada com sucesso!";
            return RedirectToAction("ListarClinica", "Clinica");
        }

        public ActionResult ExcluirEndereco(int id)
        {
            acEnderecoAcoes.deletarEndereco(id);
            ViewBag.Message = "Exclusão realizada com sucesso!";
            return RedirectToAction("ListarClinica", "Clinica");
        }

    }
}