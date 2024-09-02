using System.ComponentModel.DataAnnotations;

namespace HrApp.Dtos.Requests
{
    public class EmployerRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime HireDate { get; set; }
        public string JobTitle { get; set; }

        // Foreign Keys
        public int DepartmentId { get; set; }
        public DepartmanRequest Departman { get; set; }

        public int? ManagerId { get; set; }
        public EmployerRequest Manager { get; set; }
        public ICollection<EmployerRequest> Subordinates { get; set; }
    }
}
