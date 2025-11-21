using CollegeAPI.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingProject
{
    [TestClass]
    public class TestClass
    {
        [TestMethod]
        public void TestGetStudentsById()
        {
            // Arrange
            var students = new Student
            {
                Id = 1,
                Name = "Shruti",
                Email = "shruti@gmail.com",
                Age = 22,
                City = "Blr"
            };
            var studentrepo = new Mock<Student>();
            studentrepo.Setup(s => s.Id).Returns(students.Id);
            // Act
            var result = studentrepo.Object;
            // Assert
            Assert.AreEqual(1, result.Id);

        }
}
