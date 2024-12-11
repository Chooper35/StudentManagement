using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementDAL.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string FileName { get; set; }
        [Required]
        public string FilePath { get; set; }  // Path where the file is stored
        public long FileSize { get; set; }
        [Required]
        public string MimeType { get; set; }
        public DateTime UploadedOn { get; set; }
        // Foreign Key to Student
        public int StudentId { get; set; }
        // Navigation property
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}
