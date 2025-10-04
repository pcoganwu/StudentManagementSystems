using DOTNET.Lib.Models;

namespace DOTNET.BLL.Interfaces
{
    public interface IEnrollmentRespository
    {
        Task<IList<Enrollment>> GetAllEnrollments();
        Task<Enrollment> GetEnrollmentById(int id);
        Task<Enrollment> AddEnrollment(Enrollment newEnrollment);
        Task<Enrollment> UpdateEnrollment(Enrollment updatedEnrollment);
        void DeleteEnrollment(int id);
    }
}
