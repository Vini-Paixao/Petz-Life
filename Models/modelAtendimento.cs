using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Tcc.Models
{
    public class modelAtendimento
    {
        [Display(Name = "Código")]
        public int idAtendimento { get; set; }

        [Display(Name = "Data e Hora")]
        public DateTime dataHoraAtendimento { get; set; }

        [Display(Name = "Descrição")]
        public string descricaoAtendimento { get; set; }

        // STATUS

        [Display(Name = "Código de Status")]
        public int idStatus { get; set; }

        [Display(Name = "Nome de Status")]
        public string nomeStatus { get; set; }

        // CLINICA

        [Display(Name = "Código de Clinica")]
        public int idClinica { get; set; }

        [Display(Name = "Nome de Clinica")]
        public string nomeClinica { get; set; }

        // VETERINÁRIO

        [Display(Name = "Código de Veterinário")]
        public int idVeterinario { get; set; }

        [Display(Name = "Nome de Veterinário")]
        public string nomeVeterinario { get; set; }

        [Display(Name = "Especialidade de Veterinário")]
        public string especVeterinario { get; set; }

        // ANIMAL

        [Display(Name = "Código do Animal")]
        public int idAnimal { get; set; }

        [Display(Name = "Nome do Animal")]
        public string nomeAnimal { get; set; }

        // CLIENTE

        [Display(Name = "Código do Cliente")]
        public int idCliente { get; set; }

        [Display(Name = "Nome do Cliente")]
        public string nomeCliente { get; set; }

        // ENDEREÇO

        [Display(Name = "Código do Endereço")]
        public int idEndereco { get; set; }

        [Display(Name = "Logradouro")]
        public string logradouroEndereco { get; set; }

        [Display(Name = "Número")]
        public string numeroEndereco { get; set; }

        [Display(Name = "CEP")]
        public string cepEndereco { get; set; }

        [Display(Name = "Bairro")]
        public string bairroEndereco { get; set; }

        [Display(Name = "Cidade")]
        public string cidadeEndereco { get; set; }

        [Display(Name = "Estado")]
        public string siglaEstado { get; set; }
    }
}