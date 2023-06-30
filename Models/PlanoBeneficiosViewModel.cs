using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tcc.Models
{
    public class PlanoBeneficiosViewModel
    {
        public int idPlano { get; set; }
        public string nomePlano { get; set; }
        public string valorPlano { get; set; }
        public string corPlano { get; set; }
        public string imgPlano { get; set; }
        public string descPlano { get; set; }
        public List<Beneficio> Beneficios { get; set; }
    }
    public class Beneficio
    {
        public string nomeBeneficio { get; set; }
    }
}