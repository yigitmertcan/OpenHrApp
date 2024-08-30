using System.ComponentModel.DataAnnotations;

namespace HrApp.Models
{
    public class TrainingModel
    {
        [Key]
        public int TrainingId { get; set; }
        public string TrainingName { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
