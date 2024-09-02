using Hangfire.Common;
using System.ComponentModel.DataAnnotations;

namespace HrApp.Dtos.Requests
{
    public class RecruitmentRequest
    {
        public int JobId { get; set; }
        public JobRequest Job { get; set; }
        public string ApplicantName { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string Status { get; set; }
    }
}
