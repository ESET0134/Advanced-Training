using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Student_Database.Models;
using System.Xml.XPath;
using Microsoft.EntityFrameworkCore;

namespace Student_Database.Data.Repository
{
    public class StudentRepository : IstudentRepository
    {
        private readonly CollegeContext _dbcontext;

        public StudentRepository(CollegeContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> CreateStudent(Student student)
        {
            _dbcontext.Students.Add(student);
            await _dbcontext.SaveChangesAsync();
            return 1;
        }

        public async Task<bool> DeleteStudent(int id)
        {
            var deleting = _dbcontext.Students.Where(n => n.Id == id).FirstOrDefault();
            _dbcontext.Students.Remove(deleting);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Student>> GetAll()
        {
            return await _dbcontext.Students.ToListAsync();
        }

        public async Task<Student> GetStudentsByID(int id)
        {
            return await _dbcontext.Students.Where(n => n.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Student> GetStudentsByName(string Name)
        {
            return await _dbcontext.Students.Where(n => n.Name == Name).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateStudent(Student student)
        {
            if (student == null || student.Id == 0)
                return 0;
            var existing = await _dbcontext.Students.FindAsync(student.Id);
            if (existing == null)
                return 0;
            existing.Name = student.Name;
            existing.Email = student.Email;
            existing.Age = student.Age;
            existing.City = student.City;

            await _dbcontext.SaveChangesAsync();
            return 1;
        }
    }
}
