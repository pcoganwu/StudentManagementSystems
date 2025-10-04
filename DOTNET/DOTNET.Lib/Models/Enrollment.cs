using System.Diagnostics;

namespace DOTNET.Lib.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public Grade Grade { get; set; }

        public int StudentID { get; set; }
        public Student? Student { get; set; }

        public int CourseID { get; set; }
        public Course? Course { get; set; }
    }
}
