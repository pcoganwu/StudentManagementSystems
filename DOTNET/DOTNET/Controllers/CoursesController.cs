using DOTNET.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository=courseRepository;
        }

        public async Task<IActionResult> Index()
        {
            var courses = await _courseRepository.GetAllCourses();
            return View(courses);
        }

        public async Task<IActionResult> Details(int id)
        {
            var course = await _courseRepository.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }
    }
}
