using DOTNET.BLL.Interfaces;
using DOTNET.BLL.Repositories;
using DOTNET.BLL.ViewModels;
using DOTNET.Data.Data;
using DOTNET.Lib.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DOTNET.Controllers
{
    //[Route("Student")]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        ///Views/Student/Index.cshtml
        ///Views/Shared/Index.cshtml
        //[Route("")]
        //[Route("All")]
        [Route("[action]")]
        public async Task<ViewResult> Index()
        {
            IList<Student> students = await _studentRepository.GetAllStudents();
            return View(students);
        }

        // https://localhost:5000/student/GetStudentDetails/1
       /* [Route("GetStudentDetails/{id:int}")]*/ // add a constraint
        [Route("[action]/{id:int}")] // add a constraint
        public async Task<ViewResult> GetStudentDetails(int id)

        {
            //MemoryDbContext context = new MemoryDbContext();
            //MockStudentRepository repo = new MockStudentRepository(context);

            Student? student = await _studentRepository.GetStudentById(id);

            //Student? student = await repo.GetStudentById(id);

            //ViewData["PageTitle"] = "Student Details";
            //ViewData["Student"] = student;

            //ViewBag.PageTitle = "Student Details";
            //ViewBag.Student = student;

            StudentViewModel studentViewModel = new StudentViewModel()
            {
                PageTitle = "Student Details",
                Student = student ?? new Student()
            };

            return View(studentViewModel);
        }

        //Student/studentId/Courses
        [Route("/student/{studentId}/courses")]
        public ViewResult GetStudentCourse(int studentId)
        {
            IList<string> courses =_studentRepository.GetStudentCourses(studentId);
            return View(courses);
        }
    }
}
