
using Microsoft.AspNetCore.Mvc;
using StudentManagementBUS.StudentDal;
using StudentManagementDAL.Data;
using StudentManagementDAL.Models;

namespace AyberkInterview.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDBContext _studentDbContext;
        private readonly StudentService _studentService;
        public StudentController(StudentDBContext context , StudentService studentService)
        {
            _studentDbContext = context;
            _studentService = studentService;
        }

        public IActionResult Index()
        {           
           var students = _studentService.GetAllStudents();
           return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            student.UniversityId = 1;
            try
            {
                _studentService.AddStudent(student);
                TempData["Message"] = "Student created successfully!";
                return RedirectToAction("UploadDocument", new { StudentId = student.Id });
                //return RedirectToAction(nameof(Index));

            }
            catch (Exception ex) {

                return View(student);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var _student = _studentService.GetStudentById(id);
            if (_student == null)
            {
                //return NotFound();
                //throw notification Student Not Found!
                return RedirectToAction(nameof(Index));
            }
            return View(_student);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (student.Id != 0)
            {
                _studentService.UpdateStudent(student);
                TempData["Message"] = "Student updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            TempData["ErrorMessage"] = "Student not found!";
            return View(student);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _studentService.DeleteStudent(id);
            if (!result)
            {
                TempData["ErrorMessage"] = "Student not found!";
                return NotFound();
            }
            TempData["Message"] = "Student deleted successfully!";
            return RedirectToAction("Index"); 
        }

    }
}
