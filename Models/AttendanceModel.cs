using System.ComponentModel.DataAnnotations;

namespace HrApp.Models
{
    public class AttendanceModel
    {
        [Key]
        public int AttendanceId { get; set; }
        public int EmployeeId { get; set; }
        public EmployerModel Employee { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
        public DateTime Date { get; set; }
    }
}
