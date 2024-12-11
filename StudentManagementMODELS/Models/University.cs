using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementMODELS.Models
{
    public  class University
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "University name is required.")]
        [StringLength(100, ErrorMessage = "University name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        [StringLength(250, ErrorMessage = "Address cannot be longer than 250 characters.")]
        public string Address { get; set; }

        [StringLength(50, ErrorMessage = "City name cannot be longer than 50 characters.")]
        public string City { get; set; }

        // Navigation property for related Students
        public ICollection<Student> Students { get; set; }
    }
}
