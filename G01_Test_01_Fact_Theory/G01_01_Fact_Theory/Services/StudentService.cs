using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G01_01_Fact_Theory.Services
{
    public class StudentService
    {
        public string InsertTest()
        {
            return "SUCCESS: ok!";
        }

        public string InsertStudent(string nome, string cognome)
        {
            return $"SUCCESS: {nome} {cognome}";
        }
    }
}
