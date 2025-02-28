using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Containers.Models
{
    public class Studente
    {
        public string Nome { get; set; } = null!;
        public string Cognome { get; set; } = null!;
        public string Matricola { get; set; } = null!;
        public DateTime Ts { get; set; } = DateTime.Now;    //Data inserimento
    }
}
