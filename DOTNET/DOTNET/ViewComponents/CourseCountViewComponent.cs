using DOTNET.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET.ViewComponents
{
    public class CourseCountViewComponent : ViewComponent
    {
        private readonly IEnrollmentRespository _enrollmentRespository;

        public CourseCountViewComponent(IEnrollmentRespository enrollmentRespository)
        {
            _enrollmentRespository=enrollmentRespository;
        }
    }
}
