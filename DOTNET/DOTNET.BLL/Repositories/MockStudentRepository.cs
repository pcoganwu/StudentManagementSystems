using DOTNET.BLL.Interfaces;
using DOTNET.Data.Data;
using DOTNET.Lib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections;

namespace DOTNET.BLL.Repositories
{
    public class MockStudentRepository : IStudentRepository
    {
        private readonly MemoryDbContext _context;

        public MockStudentRepository(MemoryDbContext context)
        {
            _context = context;
            SeedData();
        }

        public MockStudentRepository()
        {
        }

        public void SeedData()
        {
            // Prevent duplicate seeding
            if (_context.Students.Any())
                return;

            Student s1 = new Student()
            {
                Id = 1,
                FirstName = "Andy",
                Initials = "A",
                LastName = "Young",
                Gender = Gender.Male,
                EnrollmentDate = new DateTime(2020, 9, 1)
            };

            Student s2 = new Student()
            {
                Id = 2,
                FirstName = "Jane",
                Initials = "Y",
                LastName = "Harrison",
                Gender = Gender.Female,
                EnrollmentDate = new DateTime(2020, 10, 10)
            };

            Student s3 = new Student()
            {
                Id = 3,
                FirstName = "Kate",
                Initials = "G",
                LastName = "George",
                Gender = Gender.Unknown,
                EnrollmentDate = new DateTime(2020, 8, 11)
            };

            Student s4 = new Student()
            {
                Id = 4,
                FirstName = "Marc",
                Initials = "H",
                LastName = "Bredd",
                Gender = Gender.Male,
                EnrollmentDate = new DateTime(2020, 10, 13)
            };

            _context.Students.AddRange(s1, s2, s3, s4);
            _context.SaveChanges();
        }

        public async Task<Student> AddStudent(Student newStudent)
        {
            // Handle empty set safely
            newStudent.Id = _context.Students.Any() ? (_context.Students.Max(x => x.Id) + 1) : 1;

            EntityEntry<Student> student = await _context.Students.AddAsync(newStudent);
            await _context.SaveChangesAsync();
            return student.Entity;
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
            return await _context.Students.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Student> UpdateStudent(Student updatedStudent)
        {
            Student? studentToUpdate = await _context.Students.FirstOrDefaultAsync(s => s.Id == updatedStudent.Id);
            if (studentToUpdate == null)
            {
                return null!;
            }

            studentToUpdate.FirstName = updatedStudent.FirstName;
            studentToUpdate.Initials = updatedStudent.Initials;
            studentToUpdate.LastName = updatedStudent.LastName;
            studentToUpdate.Gender = updatedStudent.Gender;
            studentToUpdate.EnrollmentDate = updatedStudent.EnrollmentDate;

            _context.Students.Update(studentToUpdate);

            await _context.SaveChangesAsync();
            return studentToUpdate;
        }

        public IList<string> GetStudentCourse(int studentID)
        {
            IList<string> courseList = new List<string>();

            if (studentID == 1)
                courseList = new List<string>() { "ASP.NET Core", "C# .NET", "SQLServer" };
            else if (studentID == 2)
                courseList = new List<string>() { "ASP.NET Core MVC", "C# .NET", "ADO.NET Core" };
            else if (studentID == 3)
                courseList = new List<string>() { "ASP.NET Core WEB API", "C# .NET", "Entity Framework Core" };
            else
                courseList = new List<string>() { "BootStrap", "jQuery", "JavaSCript" };

            return courseList;
        }
    }
}
