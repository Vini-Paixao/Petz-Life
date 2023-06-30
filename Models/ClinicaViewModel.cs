using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tcc.Models
{
    public class ClinicaViewModel
    {
        public int idClinica { get; set; }
        public string nomeClinica { get; set; }
        public string telefoneClinica { get; set; }
        public string celularClinica { get; set; }
        public string emailClinica { get; set; }
        public string avaliacaoClinica { get; set; }
        public string horarioClinica { get; set; }
        public int idEndereco { get; set; }
        public List<Veterinario> Veterinarios { get; set; }
    }
    public class Veterinario
    {
        public int idVeterinario { get; set; }
        public string nomeVeterinario { get; set; }
        public string especVeterinario { get; set; }
    }
}