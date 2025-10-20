using DOTNET.BLL.Interfaces;
using DOTNET.Data.Data;
using DOTNET.Lib.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DOTNET.BLL.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        private readonly ApplicationDbContext _context;

        public CourseRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory=dbContextFactory;
            _context = dbContextFactory.CreateDbContext();
        }

        public async Task<Course> AddCourse(Course newCourse)
        {
            var course = await _context.Courses.AddAsync(newCourse);
            await _context.SaveChangesAsync();
            return course.Entity;
        }

        public async Task DeleteCourse(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);

            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IList<Course>> GetAllCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseById(int id)
        {
            var course =  await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);

            if (course == null)
            {
                return null!;
            }

            return course;
        }

        public async Task<Course> UpdateCourse(Course updatedCourse)
        {
            var existingCourse = await _context.Courses.FirstOrDefaultAsync(c => c.Id == updatedCourse.Id);

            if (existingCourse == null)
            {
                return null!;
            }

            existingCourse.Title = updatedCourse.Title;
            existingCourse.Credit = updatedCourse.Credit;
            existingCourse.Instructor = updatedCourse.Instructor;

            _context.Courses.Update(existingCourse);
            await _context.SaveChangesAsync();

            return updatedCourse;
        }
    }
}
