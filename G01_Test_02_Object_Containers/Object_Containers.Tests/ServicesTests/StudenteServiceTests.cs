using FluentAssertions;
using Object_Containers.Models;
using Object_Containers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Containers.Tests.ServicesTests
{
    public class StudenteServiceTests
    {
        [Theory]
        [InlineData("Giovanni", "Pace")]
        [InlineData("Valeria", "Verdi")]
        public void StudentService_InsertStudent_ShouldReturnObject(string n, string c)
        {
            //Arrange
            var service = new StudenteService();

            var exp = new Studente()
            {
                Cognome = c,
                Nome = n,
            };

            //Act
            Studente risultato = service.InsertStudente(n,c);

            //Assert
            risultato.Should().NotBeNull();
            risultato.Nome.Should().Be(exp.Nome);
            risultato.Cognome.Should().Be(exp.Cognome);
            risultato.Matricola.Should().NotBeNull("Il valore della matricola è null");

            bool guidValido = Guid.TryParse(risultato.Matricola, out Guid guid);
            guidValido.Should().BeTrue("GUID non valido");
        }
    }
}
