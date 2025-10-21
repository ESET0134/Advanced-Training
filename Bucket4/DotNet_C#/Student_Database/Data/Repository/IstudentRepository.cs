using Student_Database.Models;

namespace Student_Database.Data.Repository
{
    public interface IstudentRepository
    {
        List<Student> GetAll();
        Student GetStudentsByID(int id);
        Student GetStudentsByName(string Name);
        int CreateStudent(Student student);
        int UpdateStudent(Student student);
        bool DeleteStudent(int id);
    }
}