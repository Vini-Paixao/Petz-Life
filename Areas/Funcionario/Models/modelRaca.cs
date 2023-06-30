using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Tcc.Areas.Funcionario.Models
{
    public class modelRaca
    {
        [Display(Name = "Código")]
        public int idRaca { get; set; }

        [Required(ErrorMessage = "O Nome da Raça é obrigatório")]
        [Display(Name = "Nome da Raça")]
        public string nomeRaca { get; set; }


        public string idTipo { get; set; }

        [Required(ErrorMessage = "O Nome do Tipo é obrigatório")]
        [Display(Name = "Nome do Tipo")]
        public string nomeTipo { get; set; }
    }
}