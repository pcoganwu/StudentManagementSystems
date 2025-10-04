using DOTNET.Lib.Models;

namespace DOTNET.BLL.ViewModels
{
    public class StudentViewModel
    {
        public Student Student { get; set; } = new();
        public string? PageTitle { get; set; } 
    }
}
