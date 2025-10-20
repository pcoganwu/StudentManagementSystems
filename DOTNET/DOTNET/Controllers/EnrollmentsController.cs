using DOTNET.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly IEnrollmentRespository _enrollmentRespository;

        public EnrollmentsController(IEnrollmentRespository enrollmentRespository)
        {
            _enrollmentRespository=enrollmentRespository;
        }

        public async Task<IActionResult> Index()
        {
            var enrollments = await _enrollmentRespository.GetAllEnrollments();
            return View();
        }
    }
}
