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
    //[Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IStudentRepository _studentRepository;

        public StudentController(IWebHostEnvironment webHostEnvironment, IStudentRepository studentRepository)
        {
            _webHostEnvironment=webHostEnvironment;
            _studentRepository = studentRepository;
        }

        ///Views/Student/Index.cshtml
        ///Views/Shared/Index.cshtml
        //[Route("")]
        //[Route("All")]
        //[Route("[action]")]
        public async Task<ViewResult> Index()
        {
            IList<Student> students = await _studentRepository.GetAllStudents();
            return View(students);
        }

        // https://localhost:5000/student/GetStudentDetails/1
        /* [Route("GetStudentDetails/{id:int}")]*/ // add a constraint
                                                   //[Route("[action]/{id:int}")] // add a constraint
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
            IList<string> courses = _studentRepository.GetStudentCourses(studentId);
            return View(courses);
        }

        [HttpGet]
        public ViewResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            string? uniqueFileName = string.Empty;

            if (model.Photo != null)
            {
                // 6C74FB75-32CC-496C-8CED-AE722224AD5F_john.png
                uniqueFileName = ProcessUploadedFile(model);
            }

            Student student = new Student()
            {
                FirstName = model.FirstName,
                Initials = model.Initials,
                LastName = model.LastName,
                Gender = model.Gender,
                PhotoPath = uniqueFileName,
                EnrollmentDate = model.EnrollmentDate,
            };

            Student newStudent = await _studentRepository.AddStudent(student);

            //return RedirectToAction("Index", "Student");
            //return RedirectToAction("GetStudentDetails", "Student", new {id = newStudent.Id});
            return RedirectToAction(nameof(GetStudentDetails), nameof(Student), new { id = newStudent.Id });
        }

       

        [HttpGet]
        public async Task<ViewResult> UpdateStudent(int id)
        {
            Student? student = await _studentRepository.GetStudentById(id);

            if (student == null)
            {
                return null!;
            }

            UpdateStudentViewModel model = new();
            model.Id = student.Id;
            model.FirstName = student.FirstName;
            model.Initials = student.Initials;
            model.LastName = student.LastName;
            model.Gender = student.Gender;
            model.EnrollmentDate = student.EnrollmentDate;
            model.ExistingPhotoPath = student.PhotoPath;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStudent(UpdateStudentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Student? student = await _studentRepository.GetStudentById(model.Id);

            if (student == null)
            {
                return null!;
            }

            student.FirstName = model.FirstName;
            student.Initials = model.Initials;
            student.LastName = model.LastName;
            student.Gender = model.Gender;
            student.EnrollmentDate = model.EnrollmentDate;
            student.PhotoPath = model.ExistingPhotoPath;

            if (model.Photo != null)
            {
                if (model.ExistingPhotoPath != null)
                {
                    string fileName = Path.Combine(_webHostEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                    System.IO.File.Delete(fileName);
                }

                //string imageFile = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                //string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                //string filePath = Path.Combine(imageFile, uniqueFileName);

                //using (var fileStream = new FileStream(filePath, FileMode.Create))
                //{
                //    await model.Photo.CopyToAsync(fileStream);
                //}

                //student.PhotoPath = uniqueFileName;
                string uniqueFileName = ProcessUploadedFile(model);
            }
            else
            {
                 student.PhotoPath = model.ExistingPhotoPath;
            }

                await _studentRepository.UpdateStudent(student);

            return RedirectToAction(nameof(GetStudentDetails), nameof(Student), new { id = student.Id });
        }

        public async Task<IActionResult> DeleteStudent(int id)
        {
            Student? student = await _studentRepository.GetStudentById(id);
            if (student == null)
            {
                return null!;
            }

            if (student.PhotoPath != null)
            {
                string fileName = Path.Combine(_webHostEnvironment.WebRootPath, "images", student.PhotoPath);
                System.IO.File.Delete(fileName);
            }

            await _studentRepository.DeleteStudent(id);
            return RedirectToAction(nameof(Index));
        }

        private string ProcessUploadedFile(CreateStudentViewModel model)
        {
            string uniqueFileName;
            string imageFile = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
            string filePath = Path.Combine(imageFile, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                model.Photo.CopyTo(fileStream);
            }

            return uniqueFileName;
        }
    }
}
