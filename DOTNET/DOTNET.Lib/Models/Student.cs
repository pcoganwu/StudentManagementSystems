using System.Reflection;

namespace DOTNET.Lib.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? Initials { get; set; }
        public string? LastName { get; set; }
        public DateTime? EnrollmentDate { get; set; } // 1901-01-01
        public Gender Gender { get; set; }

        public IList<Enrollment>? Enrollments { get; set; }
    }
}
