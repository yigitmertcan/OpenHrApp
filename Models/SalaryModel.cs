using System.ComponentModel.DataAnnotations;

namespace HrApp.Models
{
    public class SalaryModel
    {
        [Key]
        public int SalaryId { get; set; }
        public int EmployeeId { get; set; }
        public EmployerModel Employee { get; set; }
        public decimal Amount { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
