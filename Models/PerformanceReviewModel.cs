using System.ComponentModel.DataAnnotations;

namespace HrApp.Models
{
    public class PerformanceReviewModel
    {
        [Key]
        public int ReviewId { get; set; }
        public int EmployeeId { get; set; }
        public EmployerModel Employee { get; set; }
        public DateTime ReviewDate { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
    }
}
