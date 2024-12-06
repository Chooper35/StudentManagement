using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AyberkInterview.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Range(1, 100, ErrorMessage = "Age must be between 1 and 100.")]

        [Required(ErrorMessage = "Age is required.")]
        public int Age { get; set; }
    }
}
