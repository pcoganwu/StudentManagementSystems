using DOTNET.Lib.Models;

namespace DOTNET.BLL.Interfaces
{
    public interface IStudentRepository
    {
        Task<IList<Student>> GetAllStudents();
        Task<Student?> GetStudentById(int id);
        Task<Student> AddStudent(Student newStudent);
        Task<Student> UpdateStudent(Student updatedStudent);
        Task DeleteStudent(int id);
    }
}
