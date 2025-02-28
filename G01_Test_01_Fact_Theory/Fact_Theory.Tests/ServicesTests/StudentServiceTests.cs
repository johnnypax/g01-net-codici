using FluentAssertions;
using G01_01_Fact_Theory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fact_Theory.Tests.ServicesTests
{
    public class StudentServiceTests
    {
        [Fact]
        public void StudentService_InsertTest_ShouldReturnString()
        {
            /*
             * Guard Assertions (AAA):
             * - Arrange: Inizializzazioni
             * - Act: Creo gli oggetti necessari ed invoco i metodi da testare
             * - Assert: Verifica dei risultati
             */

            //Arrange
            var studService = new StudentService();

            //Act
            var result = studService.InsertTest();

            //Assert
            //Assert.Equal("SUCCESS: ok!", result);

            result.Should().NotBeNullOrWhiteSpace();
            //result.Should().Be("SUCCESS: ok!");
            result.Should().Contain("ok!", Exactly.Once());
        }

        [Theory]
        [InlineData("Giovanni", "Pace", "SUCCESS: Giovanni Pace")]
        [InlineData("Valeria", "Verdi", "SUCCESS: Valeria Verdi")]
        public void StudentService_InsertStudent_ShouldReturnString(string nom, string cogn, string exp)
        {
            //Arrange
            var studService = new StudentService();

            //Act
            var result = studService.InsertStudent(nom, cogn);

            //Assert
            //Assert.Equal(exp, result);

            result.Should().NotBeNullOrWhiteSpace();    
            result.Should().Be(exp);
        }

    }
}
