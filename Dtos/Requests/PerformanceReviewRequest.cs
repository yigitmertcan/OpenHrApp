using System.ComponentModel.DataAnnotations;

namespace HrApp.Dtos.Requests
{
    public class PerformanceReviewRequest
    {
        public int EmployeeId { get; set; }
        public EmployerRequest Employee { get; set; }
        public DateTime ReviewDate { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
    }
}
