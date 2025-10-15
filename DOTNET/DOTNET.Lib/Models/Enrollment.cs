using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace DOTNET.Lib.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public Grade Grade { get; set; }

        public int StudentID { get; set; }
        public Student? Student { get; set; } // Navigation property

        public int CourseID { get; set; }
        public Course? Course { get; set; } // Navigation property
    }
}
