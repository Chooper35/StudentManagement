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
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Edit(Student student)
        {
            var _student = _studentDbContext.Students.FirstOrDefault(p => p.Id == student.Id);
            if (_student == null)
            {
                //return NotFound();
                //throw notification Student Not Found!
                return RedirectToAction(nameof(Index));
            }
            return View(_student);
        }
        [HttpPost]
        public IActionResult SaveEdit(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentDbContext.Update(student);
                _studentDbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

    }
}
