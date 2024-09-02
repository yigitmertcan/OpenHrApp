using System.ComponentModel.DataAnnotations;

namespace HrApp.Dtos.Requests
{
    public class LeaveRequestRequest
    {
        public int EmployeeId { get; set; }
        public EmployerRequest Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LeaveType { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
    }
}
