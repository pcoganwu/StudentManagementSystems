using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DOTNET.Lib.Models
{
    public class Student
    {
        public int Id { get; set; }

        //[Required]
        //[MaxLength(50)]
        //[Display(Name = "First Name")]
        [Required(ErrorMessage = "First name in required"), MaxLength(50), Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [MaxLength(3, ErrorMessage = "Maximum characters allowed is 3")]
        public string? Initials { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Display(Name = "Photo")]
        [MaxLength(400)]
        public string? PhotoPath { get; set; }

        [Required]
        [Display(Name = "Enrollment Date")]
        public DateTime? EnrollmentDate { get; set; } // 1901-01-01

        [Required]
        public Gender Gender { get; set; }

        public IList<Enrollment>? Enrollments { get; set; }
    }
}
