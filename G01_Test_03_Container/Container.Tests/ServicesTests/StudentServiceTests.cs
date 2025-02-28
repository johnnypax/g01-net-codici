using Container.Model;
using Container.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container.Tests.ServicesTests
{
    public class StudentServiceTests
    {
        private readonly StudentService _studentService;

        public StudentServiceTests()
        {
            _studentService = new StudentService();
        }

        [Theory]
        [InlineData("Giovanni", "Pace")]
        [InlineData("Valeria", "Verdi")]
        public void StudentService_InsertStudent_ShouldReturnTrue(string fir, string las)
        {
            //Arrange
            var exp = new Student() { FirstName = fir, LastName = las };

            //Act
            var countBefore = _studentService.ListCounter();
            var result = _studentService.InsertStudent(fir, las);
            var countAfter = _studentService.ListCounter();

            var studentList = _studentService.FindAll();

            //Assert
            //Assert.True(result, "Studente non inserito");
            //Assert.Equal(countBefore + 1, countAfter);

            result.Should().NotBe(false);
            countBefore.Should().BeLessThan(countAfter);

            studentList.Should().BeOfType<List<Student>>();

            studentList.Should().Contain(
                s => (s.FirstName == exp.FirstName && s.LastName == exp.LastName));

        }
    }
}
