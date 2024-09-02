using System.ComponentModel.DataAnnotations;

namespace HrApp.Dtos.Requests
{
    public class TrainingRequest
    {
        public string TrainingName { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
