using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Tcc.Areas.Funcionario.Models
{
    public class modelPlano
    {
        [Display(Name = "Código")]
        public int idPlano { get; set; }

        [Required(ErrorMessage = "O Nome do Plano é obrigatório")]
        [Display(Name = "Nome")]
        public string nomePlano { get; set; }

        [Required(ErrorMessage = "A Tag do Plano é obrigatório")]
        [Display(Name = "Tag")]
        public string tagPlano { get; set; }

        [Required(ErrorMessage = "O Valor do Plano é obrigatório")]
        [Display(Name = "Valor")]
        public string valorPlano { get; set; }

        [Required(ErrorMessage = "O Tipo do Plano é obrigatório")]
        [Display(Name = "Tipo")]
        public string tipoPlano { get; set; }

        [Required(ErrorMessage = "A Cor do Plano é obrigatório")]
        [Display(Name = "Cor")]
        public string corPlano { get; set; }

        [Required(ErrorMessage = "A Imagem do Plano é obrigatório")]
        [Display(Name = "Imagem")]
        public string imgPlano { get; set; }

        [Required(ErrorMessage = "A Descrição do Plano é obrigatório")]
        [Display(Name = "Descrição")]
        public string descPlano { get; set; }

    }
}