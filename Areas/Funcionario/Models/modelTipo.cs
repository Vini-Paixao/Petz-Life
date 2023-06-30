using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Tcc.Areas.Funcionario.Models
{
    public class modelTipo
    {
        [Display(Name = "Código")]
        public int idTipo { get; set; }

        [Required(ErrorMessage = "O Nome do Tipo de Animal é obrigatório")]
        [Display(Name = "Nome")]
        public string nomeTipo { get; set; }
    }
}