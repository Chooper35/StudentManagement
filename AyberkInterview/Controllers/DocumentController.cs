using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementDAL.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentManagementDAL.Models;

namespace AyberkInterview.Controllers
{
    [Route("Document")]
    public class DocumentController : Controller
    {
        private readonly StudentDBContext _context;
        private readonly string _uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

        public DocumentController(StudentDBContext context)
        {
            _context = context;
            // Ensure upload folder exists
            if (!Directory.Exists(_uploadFolder))
            {
                Directory.CreateDirectory(_uploadFolder);
            }
        }
        [HttpPost("upload")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> UploadDocument(IFormFile file, int studentId)
        {
            if (file == null || file.Length == 0)
                return Json(new { success = false, message = "No file uploaded." });

            // Generate a unique file name to avoid overwriting
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(_uploadFolder, fileName);

            if (System.IO.File.Exists(filePath))
            {
                // Create a unique name if the file already exists
                fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                filePath = Path.Combine(_uploadFolder, fileName);
            }

            // Save the file to disk
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Save file metadata to the database
            var document = new Document
            {
                StudentId = studentId,
                FileName = fileName,
                FilePath = filePath,
                FileSize = file.Length,
                MimeType = file.ContentType,
                UploadedOn = DateTime.UtcNow
            };

            _context.Documents.Add(document);
            await _context.SaveChangesAsync();
            //return Json(new { success = true, fileId = document.Id, fileName = document.FileName });
            return RedirectToAction("Student","Index");
        }

        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadDocument(int id)
        {
            var document = await _context.Documents
                .Where(d => d.Id == id)
                .FirstOrDefaultAsync();

            if (document == null)
                return NotFound();

            var fileBytes = System.IO.File.ReadAllBytes(document.FilePath);
            return File(fileBytes, document.MimeType, document.FileName);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
