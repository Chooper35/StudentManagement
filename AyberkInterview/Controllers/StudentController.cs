using AyberkInterview.DataAccessLayers;
using AyberkInterview.Models;
using Microsoft.AspNetCore.Mvc;

namespace AyberkInterview.Controllers
{
    public class StudentController : Controller
    {
        public StudentDbContext _studentDbContext;
        public StudentController(StudentDbContext context)
        {
            _studentDbContext = context;
        }

        public IActionResult Index()
        {
           var students = _studentDbContext.Students.ToList();
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
            if (ModelState.IsValid)
            {
                _studentDbContext.Add(student);
                _studentDbContext.SaveChanges();
                TempData["Message"] = "Student created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var _student = _studentDbContext.Students.FirstOrDefault(p => p.Id == id);
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
            if (ModelState.IsValid)
            {
                _studentDbContext.Update(student);
                _studentDbContext.SaveChanges();
                TempData["Message"] = "Student updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            TempData["ErrorMessage"] = "Student not found!";
            return View(student);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            //Before delete ask for confirmation
            var student = _studentDbContext.Students.Find(id);
            if (student == null)
            {
                TempData["ErrorMessage"] = "Student not found!";
                return NotFound();
            }
            _studentDbContext.Students.Remove(student); 
            _studentDbContext.SaveChanges();
            TempData["Message"] = "Student deleted successfully!";
            return RedirectToAction("Index"); 
        }

    }
}
