using Container.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container.Services
{
    public class StudentService
    {
        private ICollection<Student> students = new List<Student>();

        public int ListCounter()
        {
            return students.Count;
        }

        public ICollection<Student> FindAll()
        {
            return students;
        }

        public bool InsertStudent(string varFirst, string varLast)
        {
            if (string.IsNullOrEmpty(varFirst) || string.IsNullOrEmpty(varLast))
                return false;

            Student student = new Student()
            {
                FirstName = varFirst,
                LastName = varLast
            };

            //students.Add(student);
            return true;
        }

    }
}
