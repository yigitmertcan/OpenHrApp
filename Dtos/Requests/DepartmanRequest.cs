using System.ComponentModel.DataAnnotations;

namespace HrApp.Dtos.Requests
{
    public class DepartmanRequest
    {
        public string DepartmanName { get; set; }
        public string Location { get; set; }

        public ICollection<EmployerRequest> Employees { get; set; }
    }
}
