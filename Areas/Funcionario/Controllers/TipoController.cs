using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tcc.Areas.Funcionario.Dados;
using Tcc.Areas.Funcionario.Models;

namespace Tcc.Areas.Funcionario.Controllers
{
    public class TipoController : Controller
    {
        acTipo acTipoAcoes = new acTipo();
        modelTipo modTipo = new modelTipo();

        public ActionResult CadTipo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadTipo(modelTipo cl)
        {
            acTipoAcoes.inserirTipo(cl);
            ViewBag.Message = "Cadastro realizado com sucesso!";
            return RedirectToAction(nameof(ListarTipo));
        }

        public ActionResult ListarTipo()
        {
            return View(acTipoAcoes.buscarTipo());
        }

        public ActionResult EditarTipo(int id)
        {
            return View(acTipoAcoes.buscarTipo().Find(modTipo => modTipo.idTipo == id));
        }

        [HttpPost]
        public ActionResult EditarTipo(modelTipo cl)
        {
            acTipoAcoes.atualizarTipo(cl);
            ViewBag.Message = "Alteração realizada com sucesso!";
            return RedirectToAction(nameof(ListarTipo));
        }

        public ActionResult ExcluirTipo(int id)
        {
            acTipoAcoes.deletarTipo(id);
            ViewBag.Message = "Exclusão realizada com sucesso!";
            return RedirectToAction(nameof(ListarTipo));
        }
    }
}