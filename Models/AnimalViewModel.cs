using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Tcc.Models
{
    public class AnimalViewModel
    {   
        // DADOS DO PET

        public int idAnimal { get; set; }
        public string nomeAnimal { get; set; }
        public string apelidoAnimal { get; set; }
        public int idadeAnimal { get; set; }
        public string imgAnimal { get; set; }
        public string nomeRaca { get; set; }
        public string nomeTipo { get; set; }
        public int idLogin { get; set; }
        public int idCliente { get; set; }
        public List<Informacao> Informacoes { get; set; }
        public List<Cuidado> Cuidados { get; set; }
    }
    public class Informacao
    {
        public string descInformacao { get; set; }
    }
    public class Cuidado
    {
        public string descCuidado { get; set; }
    }
}