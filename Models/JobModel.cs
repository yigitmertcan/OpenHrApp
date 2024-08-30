using System.ComponentModel.DataAnnotations;

namespace HrApp.Models
{
    public class JobModel
    {
        [Key]
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
    }
}
