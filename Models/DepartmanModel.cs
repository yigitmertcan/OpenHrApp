using System.ComponentModel.DataAnnotations;

namespace HrApp.Models
{
    public class DepartmanModel
    {
        [Key]
        public int DepartmantId { get; set; }
        public string DepartmanName { get; set; }
        public string Location { get; set; }

        public ICollection<EmployerModel> Employees { get; set; }
    }
}
