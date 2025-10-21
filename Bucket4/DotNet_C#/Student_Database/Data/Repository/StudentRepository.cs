using Microsoft.AspNetCore.Mvc;
using Student_Database.Models;
using System.Xml.XPath;

namespace Student_Database.Data.Repository
{
    public class StudentRepository : IstudentRepository
    {
        private readonly CollegeContext _dbcontext;

        public StudentRepository(CollegeContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public int CreateStudent(Student student)
        {
            _dbcontext.Students.Add(student);
            _dbcontext.SaveChanges();
            return 1;
        }

        public bool DeleteStudent(int id)
        {
            var deleting = _dbcontext.Students.Where(n => n.Id == id).FirstOrDefault();
            _dbcontext.Students.Remove(deleting);
            _dbcontext.SaveChanges();
            return true;
        }

        public List<Student> GetAll()
        {
            return _dbcontext.Students.ToList();
        }

        public Student GetStudentsByID(int id)
        {
            return _dbcontext.Students.Where(n => n.Id == id).FirstOrDefault();
        }

        public Student GetStudentsByName(string Name)
        {
            return _dbcontext.Students.Where(n => n.Name == Name).FirstOrDefault();
        }

        public int UpdateStudent(Student student, [FromBody] JsonPatchDocument<Student> patchDocument)
        {
            var studentupdated = new Student()
            {
                Name = student.Name,
                Age = student.Age,
                Email = student.Email,
                City = student.City
            };
            patchDocument.ApplyTo(student, ModelState);
            if (!ModelState.IsValid)
            {
                return 0;
            }
            student.Name = student.Name;
            student.Age = student.Age;
            student.Email = student.Email;
            student.City = student.City;

            _dbcontext.SaveChanges();
            return 1;
        }
    }
}
