using System.ComponentModel.DataAnnotations;

namespace HrApp.Dtos.Requests
{
    public class JobRequest
    {
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
    }
}
