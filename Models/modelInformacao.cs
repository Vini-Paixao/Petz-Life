using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Tcc.Models
{
    public class modelInformacao
    {
        [Display(Name = "Código")]
        public int idInformacao { get; set; }

        [Display(Name = "Informação")]
        public string descInformacao { get; set; }

        public int idAnimal { get; set; }
        public string nomeAnimal { get; set; }
    }
}