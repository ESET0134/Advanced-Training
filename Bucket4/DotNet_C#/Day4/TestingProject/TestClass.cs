using College_App.Data;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
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


        /* [TestMethod]
         public void TestgetSum()
         {
             int a = 5;
             int b = 10;
             int expectedSum = a+b;
             int actualSum = getSum(a, b);
             Assert.AreEqual(expectedSum, actualSum);
             Assert.AreNotEqual(a-b, actualSum);
         }

         [TestMethod]
         public void TestgetFullName()
         {
             string firstName = "Shruti";
             string lastName = "Singhania";
             string expectedFullName = firstName + lastName;
             string actualFullName = getFullName(firstName, lastName);
             Assert.AreEqual(expectedFullName, actualFullName);
             Assert.AreNotEqual(firstName + " " + lastName, actualFullName);
         }
         private int getSum(int a, int b)
         {
             return a + b;
         }

         private string getFullName(string firstName, string lastName)
         {
             var fullName = firstName + lastName;
             return fullName;
         }*/
    }
}
