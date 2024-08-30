using Hangfire.Common;
using System.ComponentModel.DataAnnotations;

namespace HrApp.Models
{
    public class RecruitmentModel
    {
        [Key]
        public int RecruitmentId { get; set; }
        public int JobId { get; set; }
        public JobModel Job { get; set; }
        public string ApplicantName { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; }
    }
}
