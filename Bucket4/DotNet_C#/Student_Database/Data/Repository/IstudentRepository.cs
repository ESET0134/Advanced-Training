using Student_Database.Models;

namespace Student_Database.Data.Repository
{
    public interface IstudentRepository
    {
        Task<List<Student>> GetAll();
        Task<Student> GetStudentsByID(int id);
        Task<Student> GetStudentsByName(string Name);
        Task<int> CreateStudent(Student student);
        Task<int> UpdateStudent(Student student);
        Task<bool> DeleteStudent(int id);
    }
}