using DOTNET.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace DOTNET.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
        {}

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 2, FirstName = "Agatha", Initials = "R", LastName = "John", EnrollmentDate = new DateTime(2025, 02, 23), PhotoPath="AghathaRJohnbull.jpg" },
                new Student { Id = 3, FirstName = "Andrew", Initials = "B", LastName = "Johnson", EnrollmentDate = new DateTime(2025, 03, 18), PhotoPath="AndrewBJohnson.jpg" },
                new Student { Id = 4, FirstName = "Beauty", Initials = "U", LastName = "Karthryn", EnrollmentDate = new DateTime(2025, 01, 31), PhotoPath="BeautyUKartryn.jpg" },
                new Student { Id = 5, FirstName = "Clement", Initials = "T", LastName = "Chukwu", EnrollmentDate = new DateTime(2025, 06, 20), PhotoPath="ClementTChukwu.jpg" },
                new Student { Id = 6, FirstName = "Jane", Initials = "Y", LastName = "Harriman", EnrollmentDate = new DateTime(2025, 07, 10), PhotoPath="JaneYHarriman.jpg" },
                new Student { Id = 7, FirstName = "Josephine", Initials = "T", LastName = "Aliu", EnrollmentDate = new DateTime(2025, 02, 23), PhotoPath="JosephineTAliu.jpg" }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Title = "Introduction to Programming", Credit = 3 },
                new Course { Id = 2, Title = "Database Systems", Credit = 4 },
                new Course { Id = 3, Title = "Web Development", Credit = 3 },
                new Course { Id = 4, Title = "Data Structures and Algorithms", Credit = 4 },
                new Course { Id = 5, Title = "Software Engineering", Credit = 3 }
            );

            modelBuilder.Entity<Enrollment>().HasData(

                new Enrollment { Id = 1, CourseID = 1, StudentID = 2, Grade = Grade.A },
                new Enrollment { Id = 2, CourseID = 2, StudentID = 1, Grade = Grade.B },
                new Enrollment { Id = 3, CourseID = 2, StudentID = 1, Grade = Grade.C },
                new Enrollment { Id = 4, CourseID = 1, StudentID = 2, Grade = Grade.A }
            );
        }
    }
}
