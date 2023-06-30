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
    public class PlanoController : Controller
    {
        acPlano acPlanoAcoes = new acPlano();
        modelPlano modPlano = new modelPlano();

        public ActionResult CadPlano()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult CadPlano(modelPlano cl, HttpPostedFileBase file)
        {
            //imagem
            string arquivo = Path.GetFileName(file.FileName);
            string file2 = "/Imagens/" + arquivo;
            string _path = Path.Combine(Server.MapPath("~/Imagens"), arquivo);
            file.SaveAs(_path);

            //salvar no banco
            cl.imgPlano = file2;
            acPlanoAcoes.inserirPlano(cl);
            ViewBag.Message = "Cadastro realizado com sucesso!";
            return RedirectToAction(nameof(ListarPlano));
        }

        public ActionResult ListarPlano()
        {
            
            return View(acPlanoAcoes.buscarPlano());
        }
        public ActionResult EditarPlano(int id)
        {
            
            return View(acPlanoAcoes.buscarPlano().Find(modPlano => modPlano.idPlano == id));
        }

        [HttpPost]
        public ActionResult EditarPlano(modelPlano cl, HttpPostedFileBase file)
        {
            //imagem
            string arquivo = Path.GetFileName(file.FileName);
            string file2 = "/Imagens/" + arquivo;
            string _path = Path.Combine(Server.MapPath("~/Imagens"), arquivo);
            file.SaveAs(_path);

            //salvar no banco
            cl.imgPlano = file2;
            acPlanoAcoes.atualizarPlano(cl);
            ViewBag.Message = "Alteração realizada com sucesso!";
            return RedirectToAction(nameof(ListarPlano));
        }
        public ActionResult ExcluirPlano(int id)
        {
            acPlanoAcoes.deletarPlano(id);
            ViewBag.Message = "Exclusão realizada com sucesso!";
            return RedirectToAction(nameof(ListarPlano));
        }
    }
}