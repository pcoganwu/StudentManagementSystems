using System.ComponentModel.DataAnnotations;

namespace DOTNET.Lib.Models
{
    public class Course
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string? Title { get; set; }
        public int Credit { get; set; }
        public int InstructorID { get; set; }
        public IList<Enrollment>? Enrollments { get; set; }
    }
}
