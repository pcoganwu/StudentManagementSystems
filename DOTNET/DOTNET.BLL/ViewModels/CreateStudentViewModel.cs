using DOTNET.Lib.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DOTNET.BLL.ViewModels
{
    public class CreateStudentViewModel
    {
        [Required(ErrorMessage = "First name in required"), MaxLength(50), Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [MaxLength(3, ErrorMessage = "Maximum characters allowed is 3")]
        public string? Initials { get; set; }

        [Display(Name = "Photo")]
        public IFormFile? Photo { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        [Required]
        [Display(Name = "Enrollment Date")]
        public DateTime? EnrollmentDate { get; set; } // 1901-01-01

        [Required]
        public Gender Gender { get; set; }

        //public IList<Enrollment>? Enrollments { get; set; }
    }
}
