using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Tcc.Areas.Funcionario.Models
{
    public class modelClinica
    {
        [Display(Name = "Código")]
        public int idClinica { get; set; }

        [Required(ErrorMessage = "O Nome da Clínica é obrigatório")]
        [Display(Name = "Nome")]
        public string nomeClinica { get; set; }

        [Required(ErrorMessage = "A Telefone é obrigatório")]
        [Display(Name = "Telefone")]
        public string telefoneClinica { get; set; }

        [Required(ErrorMessage = "A Celular é obrigatório")]
        [Display(Name = "Celular")]
        public string celularClinica { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório")]
        [Display(Name = "Email")]
        public string emailClinica { get; set; }

        [Required(ErrorMessage = "A Avaliação é obrigatório")]
        [Display(Name = "Avaliação")]
        public string avaliacaoClinica { get; set; }

        [Required(ErrorMessage = "O Horário é obrigatório")]
        [Display(Name = "Horário")]
        public string horarioClinica { get; set; }


        public string idEndereco { get; set; }

        [Required(ErrorMessage = "O Nome do Endereço é obrigatório")]
        [Display(Name = "Nome do Endereço")]
        public string nomeEndereco { get; set; }

        [Required(ErrorMessage = "O Logradouro é obrigatório")]
        [Display(Name = "Logradouro")]
        public string logradouroEndereco { get; set; }

        [Required(ErrorMessage = "O Número é obrigatório")]
        [Display(Name = "Número")]
        public string numeroEndereco { get; set; }

        [Required(ErrorMessage = "O Complemento é obrigatório")]
        [Display(Name = "Complemento")]
        public string complementoEndereco { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório")]
        [Display(Name = "CEP")]
        public string cepEndereco { get; set; }

        [Required(ErrorMessage = "A Bairro é obrigatório")]
        [Display(Name = "Bairro")]
        public string bairroEndereco { get; set; }

        [Required(ErrorMessage = "A Cidade é obrigatório")]
        [Display(Name = "Cidade")]
        public string cidadeEndereco { get; set; }

        [Required(ErrorMessage = "Estado é obrigatório")]
        [Display(Name = "Estado")]

        public string siglaEstado { get; set; }

        [Required(ErrorMessage = "Estado é obrigatório")]
        [Display(Name = "Estado")]
        public string nomeEstado { get; set; }
    }
}