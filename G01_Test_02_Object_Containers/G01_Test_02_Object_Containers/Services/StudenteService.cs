using Object_Containers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Containers.Services
{
    public class StudenteService
    {
        public Studente InsertStudente(string nom, string cog)
        {
            Studente stu = new Studente()
            {
                Cognome = cog,
                Nome = nom,
                Matricola = "Guid.NewGuid().ToString()",
            };

            return stu;
        }
    }
}
