using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Tcc.Areas.Funcionario.Models
{
    public class modelVeterinario
    {
        [Display(Name = "Código")]
        public int idVeterinario { get; set; }

        [Required(ErrorMessage = "O Nome  é obrigatório")]
        [Display(Name = "Nome do(a) Veterinário(a)")]
        public string nomeVeterinario { get; set; }

        [Required(ErrorMessage = "O Telefone é obrigatório")]
        [Display(Name = "Telefone")]
        public string telefoneVeterinario { get; set; }

        [Required(ErrorMessage = "O Especialidade é obrigatório")]
        [Display(Name = "Especialidade")]
        public string especVeterinario { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório")]
        [Display(Name = "Email")]
        public string emailVeterinario { get; set; }


        public int idClinica { get; set; }

        [Required(ErrorMessage = "O Nome da Clínica é obrigatório")]
        [Display(Name = "Nome da Clínica")]
        public string nomeClinica { get; set; }
    }
}