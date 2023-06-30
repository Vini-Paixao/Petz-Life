using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Tcc.Models
{
    public class modelCuidado
    {
        [Display(Name = "Código")]
        public int idCuidado { get; set; }

        [Display(Name = "Cuidado")]
        public string descCuidado { get; set; }

        [Display(Name = "Código do Animal")]
        public int idAnimal { get; set; }

        [Display(Name = "Nome")]
        public string nomeAnimal { get; set; }
    }
}