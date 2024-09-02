using System.ComponentModel.DataAnnotations;

namespace HrApp.Models
{
    public class UserRequest
    {
        public int? EmployeeId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepatPassword { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }
}
