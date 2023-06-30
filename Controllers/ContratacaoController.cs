using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Tcc.Areas.Funcionario.Dados;
using Tcc.Areas.Funcionario.Models;
using Tcc.Dados;
using Tcc.Models;

namespace Tcc.Controllers
{
    public class ContratacaoController : Controller
    {
        acLogin acLoginAcoes = new acLogin();
        modelLogin modLogin = new modelLogin();
        acCliente acClienteAcoes = new acCliente();
        modelCliente modCliente = new modelCliente();
        acEndereco acEnderecoAcoes = new acEndereco();
        modelEndereco modEndereco = new modelEndereco();
        acAnimal acAnimalAcoes = new acAnimal();
        modelAnimal modAnimal = new modelAnimal();
        static int codigoEndereco;
        static int codigoCliente;
        static int codigoAnimal;
        static int codigoTipo;
        static int codigoLogin;
        static int codigoPlano;

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
        public void carregarRaca(int id)
        {
            List<SelectListItem> racas = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost; Port=3306; DataBase=dbTcc; User=root; pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select idRaca, nomeRaca from tbRaca where idTipo = @idTipo", con);
                cmd.Parameters.AddWithValue("@idTipo", id);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    racas.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
            }

            ViewBag.racas = new SelectList(racas, "Value", "Text");
        }

        public void carregarTipo()
        {
            List<SelectListItem> tipos = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost; Port=3306; DataBase=dbTcc; User=root; pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbTipo", con);
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

        public ActionResult TestarEmail(string Email)
        {
            bool LoginExists;
            string login = new acLogin().TestarEmail(Email);

            if (login.Length == 0)
                LoginExists = false;
            else
                LoginExists = true;

            return Json(!LoginExists, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CadLoginCliente(int id)
        {
            ViewBag.idPlano = id;
            codigoPlano = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadLoginCliente(modelLogin cl)
        {
            if (!ModelState.IsValid)
               return View(cl);

            acLoginAcoes.inserirLoginCliente(cl);
            acLoginAcoes.TestarUsuario(cl);
            codigoLogin = cl.idLogin;
            return RedirectToAction("CadEnderecoCliente", "Contratacao", new { area = "", id = codigoLogin });
        }

        public ActionResult CadEnderecoCliente(int id)
        {
            ViewBag.idLogin = id;
            carregarEstado();
            return View();
        }

        public ActionResult CancelaLogin(int id)
        {
            acLoginAcoes.deletarLoginCliente(id);
            return RedirectToAction("DetalhesPlano", "Home", new { @area = "", id = codigoPlano });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadEnderecoCliente(modelEndereco cl)
        {
            //if (!ModelState.IsValid)
            //    return View(cl);
            carregarEstado();
            cl.siglaEstado = Request["estados"];
            acEnderecoAcoes.inserirEndereco(cl);
            acEnderecoAcoes.TestarEndereco(cl);
            codigoEndereco = cl.idEndereco;
            return RedirectToAction("CadCliente", "Contratacao", new { area = "", id = codigoEndereco });
        }
        public ActionResult CadCliente(int id)
        {
            carregarTipo();
            ViewBag.idEndereco = id;
            return View();
        }

        public ActionResult CancelaEndereco(int id)
        {
            acLoginAcoes.deletarLoginCliente(codigoLogin);
            acEnderecoAcoes.deletarEndereco(id);
            return RedirectToAction("DetalhesPlano", "Home", new { @area = "", id = codigoPlano });
        }

        [HttpPost]
        public ActionResult CadCliente(modelCliente cl, string tipos)
        {
            carregarTipo();
            cl.idPlano = codigoPlano;
            cl.idLogin = codigoLogin;
            cl.idEndereco = codigoEndereco;
            acClienteAcoes.inserirCliente(cl);
            acClienteAcoes.TestarCliente(cl);
            codigoCliente = cl.idCliente;
            codigoTipo = int.Parse(tipos);
            return RedirectToAction("CadAnimal", "Contratacao", new { @area = "", id = codigoTipo });
        }

        public ActionResult CadAnimal(int id)
        {
            carregarRaca(id);
            ViewBag.idCliente = codigoCliente;
            return View();
        }

        public ActionResult CancelaCliente(int id)
        {
            acLoginAcoes.deletarLoginCliente(codigoLogin);
            acEnderecoAcoes.deletarEndereco(codigoEndereco);
            acClienteAcoes.deletarCliente(id);
            return RedirectToAction("DetalhesPlano", "Home", new { @area = "", id = codigoPlano });
        }

        [HttpPost]
        public ActionResult CadAnimal(modelAnimal cl, HttpPostedFileBase imgAnimal)
        {
            carregarRaca(codigoTipo);
            //imagem
            string arquivo = Path.GetFileName(imgAnimal.FileName);
            string file2 = "/Imagens/" + arquivo;
            string _path = Path.Combine(Server.MapPath("~/Imagens"), arquivo);
            imgAnimal.SaveAs(_path);

            //salvar no banco
            cl.imgAnimal = file2;
            cl.idCliente = codigoCliente;
            cl.idRaca = Convert.ToInt32(Request["racas"]);
            acAnimalAcoes.inserirAnimal(cl);
            return RedirectToAction("Login", "Home", new { area = "" });
        }
    }
}