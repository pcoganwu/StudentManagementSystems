using DOTNET.BLL.Interfaces;
using DOTNET.Data.Data;
using DOTNET.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace DOTNET.BLL.Repositories
{
    public class SQLStudentRepository : IStudentRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        private readonly ApplicationDbContext _context;

        public SQLStudentRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory=dbContextFactory;
            _context = dbContextFactory.CreateDbContext();
        }

        public async Task<Student> AddStudent(Student newStudent)
        {
           var createdStudent = await _context.Students.AddAsync(newStudent);
           await _context.SaveChangesAsync();
           return createdStudent.Entity;
        }

        public async Task DeleteStudent(int id)
        {
            Student? student = await _context.Students.FirstOrDefaultAsync(s => s.Id == id);

            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IList<Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetStudentById(int id)
        {
            return await _context.Students
                .Include(x => x.Enrollments!)
                    .ThenInclude(e => e.Course)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public IList<string> GetStudentCourses(int studentId)
        {
            throw new NotImplementedException();
        }

        public async Task<Student> UpdateStudent(Student updatedStudent)
        {
            Student? studentToUpdate = await _context.Students.FirstOrDefaultAsync(s => s.Id == updatedStudent.Id);
            if (studentToUpdate == null)
            {
                return null!;
            }

            _context.Students.Update(updatedStudent);

            await _context.SaveChangesAsync();
            return updatedStudent;
        }
    }
}
