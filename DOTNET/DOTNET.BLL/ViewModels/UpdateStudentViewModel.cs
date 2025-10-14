using DOTNET.Lib.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DOTNET.BLL.ViewModels
{
    public class UpdateStudentViewModel : CreateStudentViewModel
    {
        public int Id { get; set; }
        public string ExistingPhotoPath { get; set; } = string.Empty;
    }
}
