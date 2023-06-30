using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tcc.Areas.Funcionario.Dados;
using Tcc.Areas.Funcionario.Models;

namespace Tcc.Areas.Funcionario.Controllers
{
    public class FormaPagamentoController : Controller
    {
        acFormaPagamento acFormaPagamentoAcoes = new acFormaPagamento();
        modelFormaPagamento modFormaPagamento = new modelFormaPagamento();

        public ActionResult CadFormaPagamento()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadFormaPagamento(modelFormaPagamento cl)
        {
            if (!ModelState.IsValid)
                return View(cl);
            acFormaPagamentoAcoes.inserirFormaPagamento(cl);
            ViewBag.Message = "Cadastro realizado com sucesso!";
            return RedirectToAction(nameof(ListarFormaPagamento));
        }

        public ActionResult ListarFormaPagamento()
        {
            return View(acFormaPagamentoAcoes.buscarFormaPagamento());
        }

        public ActionResult EditarFormaPagamento(int id)
        {
            return View(acFormaPagamentoAcoes.buscarFormaPagamento().Find(modFormaPagamento => modFormaPagamento.idFormaPagamento == id));
        }

        [HttpPost]
        public ActionResult EditarFormaPagamento(modelFormaPagamento cl)
        {
            if (!ModelState.IsValid)
                return View(cl);
            acFormaPagamentoAcoes.atualizarFormaPagamento(cl);
            ViewBag.Message = "Alteração realizada com sucesso!";
            return RedirectToAction(nameof(ListarFormaPagamento));
        }

        public ActionResult ExcluirFormaPagamento(int id)
        {
            acFormaPagamentoAcoes.deletarFormaPagamento(id);
            ViewBag.Message = "Exclusão realizada com sucesso!";
            return RedirectToAction(nameof(ListarFormaPagamento));
        }
    }
}