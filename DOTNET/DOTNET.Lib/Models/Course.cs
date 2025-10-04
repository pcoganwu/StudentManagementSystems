namespace DOTNET.Lib.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Credit { get; set; }
        public int InstructorID { get; set; }
        public IList<Enrollment>? Enrollments { get; set; }
    }
}
