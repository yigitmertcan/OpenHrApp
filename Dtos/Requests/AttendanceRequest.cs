using System.ComponentModel.DataAnnotations;

namespace HrApp.Dtos.Requests
{
    public class AttendanceRequest
    {
        public int EmployeeId { get; set; }
        public EmployerRequest Employee { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public DateTime Date { get; set; }
    }
}
