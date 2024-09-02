using System.ComponentModel.DataAnnotations;

namespace HrApp.Dtos.Requests
{
    public class SalaryRequest
    {
        public int EmployeeId { get; set; }
        public EmployerRequest Employee { get; set; }
        public decimal Amount { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
