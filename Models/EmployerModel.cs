using System.ComponentModel.DataAnnotations;

namespace HrApp.Models
{
    public class EmployerModel
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime HireDate { get; set; }
        public string JobTitle { get; set; }

        // Foreign Keys
        public int DepartmentId { get; set; }
        public DepartmanModel Departman { get; set; }

        public int? ManagerId { get; set; }
        public EmployerModel Manager { get; set; }
        public ICollection<EmployerModel> Subordinates { get; set; }
    }
}
