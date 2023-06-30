using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Tcc.Models
{
    public class modelCliente
    {
        // DADOS DO CLIENTE

        [Display(Name = "idCliente")]
        public int idCliente { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        [Display(Name = "Nome")]
        public string nomeCliente { get; set; }

        [Required(ErrorMessage = "O Sobrenome é obrigatório")]
        [Display(Name = "Sobrenome")]
        public string sobrenomeCliente { get; set; }

        [Required(ErrorMessage = "A Telefone é obrigatório")]
        [Display(Name = "Telefone")]
        public string telefoneCliente { get; set; }

        [Required(ErrorMessage = "A Celular é obrigatório")]
        [Display(Name = "Celular")]
        public string celularCliente { get; set; }

        [Required(ErrorMessage = "O RG é obrigatório")]
        [Display(Name = "RG")]
        public string rgCliente { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [Display(Name = "CPF")]
        public string cpfCliente { get; set; }

        // DADOS DO LOGIN

        [Display(Name = "Código do Login")]
        public int idLogin { get; set; }

        [Display(Name = "usuario")]
        public string usuario { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }
        
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string senha { get; set; }

        // DADOS DO ENDEREÇO

        [Display(Name = "Código do Endereço")]
        public int idEndereco { get; set; }

        [Display(Name = "Nome do Endereço")]
        public string nomeEndereco { get; set; }

        [Display(Name = "Logradouro")]
        public string logradouroEndereco { get; set; }

        [Display(Name = "Número")]
        public string numeroEndereco { get; set; }

        [Display(Name = "Complemento")]
        public string complementoEndereco { get; set; }

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

        // DADOS DO PLANO

        [Display(Name = "Código do Plano")]
        public int idPlano { get; set; }

        [Display(Name = "Plano Contratado")]
        public string nomePlano { get; set; }

        [Display(Name = "Cor do Plano")]
        public string corPlano { get; set; }

        [Display(Name = "Imagem do Plano")]
        public string imgPlano { get; set; }

        [Display(Name = "Tipo do Plano")]
        public string tipoPlano { get; set; }
    }
}