using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace Tcc.Models
{
    public class modelLogin
    {
        public int idLogin { get; set; }

        [Display(Name = "Nome de Usuario")]
        public string usuario { get; set; }

        [Remote("TestarEmail", "Contratacao", AdditionalFields = "email", ErrorMessage = "O Email já está cadastrado")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Senha")]
        public string senha { get; set; }
        public string tipo { get; set; }

        [Display(Name = "Confirme a Senha")]
        [Compare(nameof(senha), ErrorMessage = "As senhas são diferentes")]
        public string confSenha { get; set; }

        public int idPlano { get; set; }
    }
}