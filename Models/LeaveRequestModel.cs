using System.ComponentModel.DataAnnotations;

namespace HrApp.Models
{
    public class LeaveRequestModel
    {
        [Key]
        public int LeaveRequestId { get; set; }
        public int EmployeeId { get; set; }
        public EmployerModel Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LeaveType { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
    }
}
