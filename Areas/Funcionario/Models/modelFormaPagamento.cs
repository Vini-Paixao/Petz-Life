using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Tcc.Areas.Funcionario.Models
{
    public class modelFormaPagamento
    {
        [Display(Name = "Código")]
        public int idFormaPagamento { get; set; }

        [Required(ErrorMessage = "O Nome da Forma de Pagamento é obrigatório")]
        [Display(Name = "Nome")]
        public string nomeFormaPagamento { get; set; }
    }
}