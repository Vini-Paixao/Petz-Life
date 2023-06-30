using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Tcc.Areas.Funcionario.Dados;
using Tcc.Areas.Funcionario.Models;
using Tcc.Dados;
using Tcc.Models;

namespace Tcc.Controllers
{
    public class ClienteController : Controller
    {
        acCliente acClienteAcoes = new acCliente();
        modelCliente modCliente = new modelCliente();
        acLogin acLoginAcoes = new acLogin();
        modelLogin modLogin = new modelLogin();
        acEndereco acEnderecoAcoes = new acEndereco();
        modelEndereco modEndereco = new modelEndereco();
        acClinica acClinicaAcoes = new acClinica();
        modelClinica modClinica = new modelClinica();
        acVeterinario acVeterinarioAcoes = new acVeterinario();
        modelVeterinario modVeterinario = new modelVeterinario();
        acAtendimento acAtendimentoAcoes = new acAtendimento();
        modelAtendimento modAtendimento = new modelAtendimento();
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

        public void carregarAnimal(int id)
        {
            List<SelectListItem> animal = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost; Port=3306; DataBase=dbTcc; User=root; pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("call pcd_selectAnimalPorId(@id)", con);
                cmd.CommandType.Equals(CommandType.StoredProcedure);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    animal.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
            }

            ViewBag.animal = new SelectList(animal, "Value", "Text");
        }

        public ActionResult Index()
        {
            return View(acAtendimentoAcoes.buscarUltimosAtendimentos(Convert.ToInt32(Session["idLogado"])));
        }

        public ActionResult AgendarConsulta()
        {
            return View();
        }

        public ActionResult Historico()
        {
            return View(acAtendimentoAcoes.buscarAtendimento(Convert.ToInt32(Session["idLogado"])));
        }

        public ActionResult Agenda()
        {
            return View(acAtendimentoAcoes.buscarAtendimentosAgendados(Convert.ToInt32(Session["idLogado"])));
        }

        public ActionResult DetalhesCliente(int id)
        {
            return View(acClienteAcoes.buscarCliente().Where(modelCliente => modelCliente.idLogin == id));
        }

        public ActionResult EditarCliente(int id)
        {
            return View(acClienteAcoes.buscarCliente().Find(modelCliente => modelCliente.idCliente == id));
        }
        [HttpPost]
        public ActionResult EditarCliente(modelCliente cl)
        {
            //if (!ModelState.IsValid)
            //    return View(cl);

            acClienteAcoes.atualizarCliente(cl);
            ViewBag.Message = "Alteração realizada com sucesso!";
            return RedirectToAction("DetalhesCliente", "Cliente", new { area = "", id = cl.idLogin });

        }

        public ActionResult EditarLoginCliente(int id)
        {
            return View(acLoginAcoes.buscarLogin().Find(modelLogin => modelLogin.idLogin == id));
        }
        [HttpPost]
        public ActionResult EditarLoginCliente(modelLogin cl)
        {
            if (!ModelState.IsValid)
                return View(cl);

            if (cl.senha != cl.confSenha)
            {
                ModelState.AddModelError("", "As senhas não são iguais. Por favor, verifique e tente novamente.");
                return View(cl);
            }

            acLoginAcoes.atualizarLoginCliente(cl);
            ViewBag.Message = "Cadastro realizado com sucesso!";
            return RedirectToAction("DetalhesCliente", "Cliente", new { area = "", id = cl.idLogin });
        }


        public ActionResult EditarEnderecoCliente(int id)
        {
            carregarEstado();
            return View(acEnderecoAcoes.buscarEndereco().Find(modelEndereco => modelEndereco.idEndereco == id));
        }

        [HttpPost]
        public ActionResult EditarEnderecoCliente(modelEndereco cl)
        {
            carregarEstado();
            cl.siglaEstado = Request["estados"];
            acEnderecoAcoes.atualizarEndereco(cl);
            ViewBag.Message = "Alteração realizada com sucesso!";
            return RedirectToAction("DetalhesCliente", "Cliente", new { area = "", id = Session["idLogado"] });
        }

        public ActionResult ExcluirEnderecoCliente(int id)
        {
            acEnderecoAcoes.deletarEndereco(id);
            ViewBag.Message = "Exclusão realizada com sucesso!";
            return RedirectToAction("ListarCliente", "Cliente");
        }
    }
}