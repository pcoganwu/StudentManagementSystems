using DOTNET.Lib.Models;

namespace DOTNET.BLL.Interfaces
{
    public interface ICourseRepository
    {
        Task<IList<Course>> GetAllCourses();
        Task<Course> GetCourseById(int id);
        Task<Course> AddCourse(Course newCourse);
        Task<Course> UpdateCourse(Course updatedCourse);
        Task DeleteCourse(int id);
    }
}
