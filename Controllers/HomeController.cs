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

namespace Tcc.Controllers
{
    public class HomeController : Controller
    {
        acLogin acLg = new acLogin();
        acPlano acPlanoAcoes = new acPlano();
        modelPlano modPlano = new modelPlano();
        acBeneficio acBeneficioAcoes = new acBeneficio();
        modelBeneficio modBeneficio = new modelBeneficio();
        acClinica acClinicaAcoes = new acClinica();
        modelClinica modClinica = new modelClinica();

        public ActionResult Index()
        {
            return View(acPlanoAcoes.buscarPlanoPorTipo());
        }

        public ActionResult Planos()
        {
            return View(acPlanoAcoes.buscarPlano());
        }
        public ActionResult DetalhesPlano(int id)
        {
            List<PlanoBeneficiosViewModel> viewModelPlanoBeneficios = new List<PlanoBeneficiosViewModel>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost; Port=3306; DataBase=dbTcc; User=root; pwd=12345678"))
            {
                con.Open();
                var planos = acPlanoAcoes.buscarPlano();
                foreach (var plano in planos)
                {
                    List<Beneficio> modelBene = new List<Beneficio>();
                    var beneficiosSelecionado = acBeneficioAcoes.buscarBeneficioPlano().Where(modBeneficio => modBeneficio.idPlano == plano.idPlano);

                    foreach (var beneficos in beneficiosSelecionado)
                    {
                        modelBene.Add(new Beneficio
                        {
                            nomeBeneficio = beneficos.nomeBeneficio
                        });
                    }

                    PlanoBeneficiosViewModel viewModelPlanoBeneficio = new PlanoBeneficiosViewModel
                    {

                        idPlano = plano.idPlano,
                        nomePlano = plano.nomePlano,
                        valorPlano = plano.valorPlano,
                        corPlano = plano.corPlano,
                        imgPlano = plano.imgPlano,
                        descPlano = plano.descPlano,
                        Beneficios = modelBene
                    };

                    viewModelPlanoBeneficios.Add(viewModelPlanoBeneficio);
                }
                con.Close();
            }
            ViewBag.idPlano = id;
            return View(viewModelPlanoBeneficios);
        }
        public ActionResult Sobre()
        {
            return View();
        }

        public ActionResult Clinicas()
        {
            return View(acClinicaAcoes.buscarClinica());
        }

        public ActionResult PoliticasPrivacidade()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(modelLogin verLogin)
        {
            acLg.TestarUsuario(verLogin);
            if (verLogin.email != null && verLogin.senha != null)
            {
                Session["idLogado"] = verLogin.idLogin.ToString();
                Session["usuarioLogado"] = verLogin.usuario.ToString();
                Session["emailLogado"] = verLogin.email.ToString();
                Session["senhaLogado"] = verLogin.senha.ToString();

                if (verLogin.tipo == "0")
                {
                    Session["tipoLogado0"] = verLogin.tipo.ToString();
                    return RedirectToAction("Index", "Adm", new { area = "Admin" });
                }
                else if (verLogin.tipo == "1")
                {
                    Session["tipoLogado1"] = verLogin.tipo.ToString();
                    return RedirectToAction("Index", "Principal", new { area = "Funcionario" });
                }
                else
                {
                    Session["tipoLogado2"] = verLogin.tipo.ToString();
                    return RedirectToAction("Index", "Cliente", new { area = "" });
                }
            }
            else
            {
                ViewBag.msgLogar = "Usuário não encontrado. Verifique o e-mail do usuário e senha";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["usuarioLogado"] = null;
            Session["emailLogado"] = null;
            Session["senhaLogado"] = null;
            Session["tipoLogado1"] = null;
            Session["tipoLogado2"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}