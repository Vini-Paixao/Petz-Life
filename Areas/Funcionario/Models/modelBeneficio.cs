using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Tcc.Areas.Funcionario.Models
{
    public class modelBeneficio
    {
        [Display(Name = "Código")]
        public int idBeneficio { get; set; }

        [Required(ErrorMessage = "O Nome do Benefício é obrigatório")]
        [Display(Name = "Nome do Benefício")]
        public string nomeBeneficio { get; set; }


        public int idPlano { get; set; }

        [Required(ErrorMessage = "Nome do Plano é obrigatório")]
        [Display(Name = "Nome do Plano")]
        public string nomePlano { get; set; }
    }
}