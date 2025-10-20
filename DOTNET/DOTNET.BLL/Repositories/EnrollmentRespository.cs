using DOTNET.BLL.Interfaces;
using DOTNET.Data.Data;
using DOTNET.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace DOTNET.BLL.Repositories
{
    public class EnrollmentRespository : IEnrollmentRespository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        private readonly ApplicationDbContext _context;

        public EnrollmentRespository(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory=dbContextFactory;
            _context = dbContextFactory.CreateDbContext();
        }

        public async Task<Enrollment> AddEnrollment(Enrollment newEnrollment)
        {
           var addedEnrollment = await _context.Enrollments.AddAsync(newEnrollment);
           await _context.SaveChangesAsync();
           return addedEnrollment.Entity;
        }

        public async Task DeleteEnrollment(int id)
        {
            var enrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.Id == id);

            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IList<Enrollment>> GetAllEnrollments()
        {
            return await _context.Enrollments.Include(c => c.Course).ToListAsync();
        }

        public async Task<Enrollment> GetEnrollmentById(int id)
        {
            var enrollment = await _context.Enrollments.FirstOrDefaultAsync(e => e.Id == id);

            if (enrollment == null)
            {
                return null!;
            }

            return enrollment;
        }

        public async Task<Enrollment> UpdateEnrollment(Enrollment updatedEnrollment)
        {
            var enrollmentToUpdate = await _context.Enrollments.FirstOrDefaultAsync(e => e.Id == updatedEnrollment.Id);

            if (enrollmentToUpdate == null)
            {
                return null!;
            }

            enrollmentToUpdate.StudentID = updatedEnrollment.StudentID;
            enrollmentToUpdate.CourseID = updatedEnrollment.CourseID;
            enrollmentToUpdate.Grade = updatedEnrollment.Grade;

            _context.Enrollments.Update(enrollmentToUpdate);
            await _context.SaveChangesAsync();
            return updatedEnrollment;
        }
    }
}
