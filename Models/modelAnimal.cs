using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tcc.Models
{
    public class modelAnimal
    {
        // DADOS DO PET

        [Display(Name = "Código")]
        public int idAnimal { get; set; }

        [Display(Name = "Nome")]
        public string nomeAnimal { get; set; }

        [Display(Name = "Apelido")]
        public string apelidoAnimal { get; set; }

        [Display(Name = "Idade")]
        public int idadeAnimal { get; set; }

        [Display(Name = "Imagem do PET")]
        public string imgAnimal { get; set; }

        // DADOS DA RAÇA

        [Display(Name = "Código da Raça")]
        public int idRaca { get; set; }

        [Display(Name = "Raça")]
        public string nomeRaca { get; set; }

        // DADOS DO TIPO (ESPÉCIE)

        [Display(Name = "Código da Espécie")]
        public int idTipo { get; set; }

        [Display(Name = "Espécie")]
        public string nomeTipo { get; set; }

        // DADOS DO CLIENTE

        [Display(Name = "Código do Cliente")]
        public int idCliente { get; set; }

        [Display(Name = "Código do Login")]
        public int idLogin { get; set; }
    }
}