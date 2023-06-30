using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Web;
using System.Web.Mvc;
using Tcc.Areas.Funcionario.Models;
using Tcc.Dados;
using Tcc.Models;

namespace Tcc.Controllers
{
    public class AnimalController : Controller
    {
        acAnimal acAnimalAcoes = new acAnimal();
        modelAnimal modAnimal = new modelAnimal();
        acCuidado acCuidadoAcoes = new acCuidado();
        modelCuidado modCuidado = new modelCuidado();
        acInformacao acInformacaoAcoes = new acInformacao();
        modelInformacao modInformacao = new modelInformacao();
        static int codigoAnimal;

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

        public ActionResult Index(int id)
        {
            carregarTipo();
            List<AnimalViewModel> viewModelAnimais = new List<AnimalViewModel>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost; Port=3306; DataBase=dbTcc; User=root; pwd=12345678"))
            {
                con.Open();
                var animais = acAnimalAcoes.buscarAnimal().Where(modAnimal => modAnimal.idLogin == id);

                foreach (var animal in animais)
                {
                    List<Informacao> modelInformacao = new List<Informacao>();
                    List<Cuidado> modelCuidado = new List<Cuidado>();

                    int idAnimal = animal.idAnimal;
                    var cuidadoSelecionado = acCuidadoAcoes.buscarCuidado().Where(modCuidado => modCuidado.idAnimal == idAnimal);
                    var informacaoSelecionado = acInformacaoAcoes.buscarInformacao().Where(modInformacao => modInformacao.idAnimal == idAnimal);

                    foreach (var cuidados in cuidadoSelecionado)
                    {
                        modelCuidado.Add(new Cuidado
                        {
                            descCuidado = cuidados.descCuidado
                        });
                    }

                    foreach (var informacoes in informacaoSelecionado)
                    {
                        modelInformacao.Add(new Informacao
                        {
                            descInformacao = informacoes.descInformacao
                        });
                    }

                    AnimalViewModel viewModelAnimal = new AnimalViewModel
                    {
                        idAnimal = animal.idAnimal,
                        nomeAnimal = animal.nomeAnimal,
                        apelidoAnimal = animal.apelidoAnimal,
                        idadeAnimal = animal.idadeAnimal,
                        imgAnimal = animal.imgAnimal,
                        nomeRaca = animal.nomeRaca,
                        nomeTipo = animal.nomeTipo,
                        idLogin = animal.idLogin,
                        idCliente = animal.idCliente,
                        Informacoes = modelInformacao,
                        Cuidados = modelCuidado
                    };

                    viewModelAnimais.Add(viewModelAnimal);
                }

                con.Close();
            }
            return View(viewModelAnimais);
        }


        public ActionResult CadastroAnimal(int id)
        {
            carregarRaca(id);
            return View();
        }
        [HttpPost]
        public ActionResult CadastroAnimal(modelAnimal cl, HttpPostedFileBase imgAnimal)
        {
            carregarRaca(cl.idTipo);

            //imagem
            string arquivo = Path.GetFileName(imgAnimal.FileName);
            string file2 = "/Imagens/" + arquivo;
            string _path = Path.Combine(Server.MapPath("~/Imagens"), arquivo);
            imgAnimal.SaveAs(_path);

            //salvar no banco
            cl.imgAnimal = file2; 
            cl.idRaca = Convert.ToInt32(Request["racas"]);
            cl.idCliente = acAnimalAcoes.buscarId(Convert.ToInt32(Session["idLogado"]));
            acAnimalAcoes.inserirAnimal(cl);
            ViewBag.Message = "Alteração realizada com sucesso!";
            return RedirectToAction("Index", "Animal", new { area = "", id = Session["idLogado"] });
        }

        public ActionResult EditarAnimal(int id)
        {
            modelAnimal cl = acAnimalAcoes.buscarAnimal().Find(modelAnimal => modelAnimal.idAnimal == id);
            carregarRaca(cl.idTipo);
            return View(cl);
        }
        [HttpPost]
        public ActionResult EditarAnimal(modelAnimal cl, HttpPostedFileBase imgAnimal)
        {
            carregarRaca(cl.idTipo);
            //if (!ModelState.IsValid)
            //    return View(cl);

            //imagem
            string arquivo = Path.GetFileName(imgAnimal.FileName);
            string file2 = "/Imagens/" + arquivo;
            string _path = Path.Combine(Server.MapPath("~/Imagens"), arquivo);
            imgAnimal.SaveAs(_path);

            //salvar no banco
            cl.imgAnimal = file2; 
            cl.idRaca = Convert.ToInt32(Request["racas"]);
            acAnimalAcoes.atualizarAnimal(cl);
            ViewBag.Message = "Alteração realizada com sucesso!";
            return RedirectToAction("Index", "Animal", new { area = "", id = Session["idLogado"] });
        }

        public ActionResult ListarCuidado(int id)
        {
            return View(acCuidadoAcoes.buscarCuidadoPorId(id));
        }

        public ActionResult CadastroCuidado(int id)
        {
            ViewBag.idAnimal = id;
            codigoAnimal = id;
            return View();
        }

        [HttpPost]
        public ActionResult CadastroCuidado(modelCuidado cl)
        {
            //if (!ModelState.IsValid)
            //    return View(cl);
            cl.idAnimal = codigoAnimal;
            acCuidadoAcoes.inserirCuidado(cl);
            ViewBag.Message = "Cadastro realizado com sucesso!";
            return RedirectToAction("Index", "Animal", new { area = "", id = Session["idLogado"] });
        }
        public ActionResult EditarCuidado(int id)
        {
            return View(acCuidadoAcoes.buscarCuidado().Find(modelCuidado => modelCuidado.idCuidado == id));
        }

        [HttpPost]
        public ActionResult EditarCuidado(modelCuidado cl)
        {
            //if (!ModelState.IsValid)
            //    return View(cl);
            acCuidadoAcoes.atualizarCuidado(cl);
            ViewBag.Message = "Alteração realizada com sucesso!";
            return RedirectToAction("Index", "Animal", new { area = "", id = Session["idLogado"] });
        }
        public ActionResult ExcluirCuidado(int id)
        {
            acCuidadoAcoes.deletarCuidado(id);
            ViewBag.Message = "Exclusão realizada com sucesso!";
            return RedirectToAction("Index", "Animal", new { area = "", id = Session["idLogado"] });
        }

        public ActionResult ListarInformacao(int id)
        {
            return View(acInformacaoAcoes.buscarInformacaoPorId(id));
        }

        public ActionResult CadastroInformacao(int id)
        {
            ViewBag.idAnimal = id;
            codigoAnimal = id;
            return View();
        }

        [HttpPost]
        public ActionResult CadastroInformacao(modelInformacao cl)
        {
            //if (!ModelState.IsValid)
            //    return View(cl);
            cl.idAnimal = codigoAnimal;
            acInformacaoAcoes.inserirInformacao(cl);
            ViewBag.Message = "Cadastro realizado com sucesso!";
            return RedirectToAction("Index", "Animal", new { area = "", id = Session["idLogado"] });
        }
        public ActionResult EditarInformacao(int id)
        {
            return View(acInformacaoAcoes.buscarInformacao().Find(modelInformacao => modelInformacao.idInformacao == id));
        }

        [HttpPost]
        public ActionResult EditarInformacao(modelInformacao cl)
        {
            //if (!ModelState.IsValid)
            //    return View(cl);
            acInformacaoAcoes.atualizarInformacao(cl);
            ViewBag.Message = "Alteração realizada com sucesso!";
            return RedirectToAction("Index", "Animal", new { area = "", id = Session["idLogado"] });
        }
        public ActionResult ExcluirInformacao(int id)
        {
            acInformacaoAcoes.deletarInformacao(id);
            ViewBag.Message = "Exclusão realizada com sucesso!";
            return RedirectToAction("Index", "Animal", new { area = "", id = Session["idLogado"] });
        }
    }
}