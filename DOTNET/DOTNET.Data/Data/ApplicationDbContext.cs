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
                new Course { Id = 1, Title = "Introduction to Programming", Credit = 3, Instructor = "Dr. Smith" },
                new Course { Id = 2, Title = "Database Systems", Credit = 4, Instructor = "Prof. Lee" },
                new Course { Id = 3, Title = "Web Development", Credit = 3, Instructor = "Dr. patel" },
                new Course { Id = 4, Title = "Data Structures and Algorithms", Credit = 4, Instructor = "Prof. Nguyen" },
                new Course { Id = 5, Title = "Software Engineering", Credit = 3, Instructor = "Dr. Gomez" },
                 new Course { Id = 6, Title = "Cloud Computing Basics", Credit = 3, Instructor = "Dr. Rivera" },
                new Course { Id = 7, Title = "Operating Systems", Credit = 4, Instructor = "Prof. Kim" },
                new Course { Id = 8, Title = "Computer Networks", Credit = 3, Instructor = "Dr. Ahmed" },
                new Course { Id = 9, Title = "Artificial Intelligence & Machine Learning", Credit = 4, Instructor = "Dr. Chen" },
                new Course { Id = 10, Title = "Mobile App Development", Credit = 3, Instructor = "Prof. Garcia" }
            );

            modelBuilder.Entity<Enrollment>().HasData(

                // Student 1 (now 4 courses)
                //new Enrollment { Id = 1, CourseID = 2, StudentID = 1, Grade = Grade.A },
                //new Enrollment { Id = 2, CourseID = 3, StudentID = 1, Grade = Grade.B },
                new Enrollment { Id = 15, CourseID = 4, StudentID = 1, Grade = Grade.A },
                new Enrollment { Id = 16, CourseID = 5, StudentID = 1, Grade = Grade.C },
                // Student 2 (now 3 courses)
                //new Enrollment { Id = 3, CourseID = 1, StudentID = 2, Grade = Grade.A },
                //new Enrollment { Id = 4, CourseID = 4, StudentID = 2, Grade = Grade.B },
                new Enrollment { Id = 17, CourseID = 5, StudentID = 2, Grade = Grade.A },
                // Student 3 (now 5 courses)
                //new Enrollment { Id = 5, CourseID = 2, StudentID = 3, Grade = Grade.C },
                new Enrollment { Id = 6, CourseID = 5, StudentID = 3, Grade = Grade.B },
                new Enrollment { Id = 18, CourseID = 1, StudentID = 3, Grade = Grade.A },
                new Enrollment { Id = 19, CourseID = 3, StudentID = 3, Grade = Grade.B },
                new Enrollment { Id = 20, CourseID = 7, StudentID = 3, Grade = Grade.A },
                // Student 4 (now 4 courses)
                new Enrollment { Id = 7, CourseID = 4, StudentID = 4, Grade = Grade.A },
                new Enrollment { Id = 8, CourseID = 6, StudentID = 4, Grade = Grade.B },
                new Enrollment { Id = 21, CourseID = 7, StudentID = 4, Grade = Grade.C },
                new Enrollment { Id = 22, CourseID = 8, StudentID = 4, Grade = Grade.B },
                // Student 5 (now 3 courses)
                new Enrollment { Id = 9, CourseID = 3, StudentID = 5, Grade = Grade.A },
                new Enrollment { Id = 10, CourseID = 7, StudentID = 5, Grade = Grade.A },
                new Enrollment { Id = 23, CourseID = 1, StudentID = 5, Grade = Grade.B },
                // Student 6 (now 5 courses)
                new Enrollment { Id = 11, CourseID = 8, StudentID = 6, Grade = Grade.B },
                new Enrollment { Id = 12, CourseID = 9, StudentID = 6, Grade = Grade.C },
                new Enrollment { Id = 24, CourseID = 2, StudentID = 6, Grade = Grade.A },
                new Enrollment { Id = 25, CourseID = 10, StudentID = 6, Grade = Grade.B },
                new Enrollment { Id = 26, CourseID = 5, StudentID = 6, Grade = Grade.A },
                // Student 7 (now 4 courses)
                new Enrollment { Id = 13, CourseID = 5, StudentID = 7, Grade = Grade.A },
                new Enrollment { Id = 14, CourseID = 10, StudentID = 7, Grade = Grade.B },
                new Enrollment { Id = 27, CourseID = 2, StudentID = 7, Grade = Grade.C },
                new Enrollment { Id = 28, CourseID = 4, StudentID = 7, Grade = Grade.A }
            );
        }
    }
}
