using System.ComponentModel.DataAnnotations;

namespace EmployeePortal_Angular_CoreWebApi.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

        public string Mobile { get; set; }

        public int? Age { get; set; } = 18;
        
        public int Salary { get; set; }

        public bool Status   { get; set; }
    }
}
