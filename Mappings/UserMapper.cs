using HrApp.Models;
using Microsoft.AspNetCore.Identity;

namespace HrApp.Mappings
{
    public static class UserMapper
    {
        public static UserModel ToUser(this UserRequest request)
        {
            return new UserModel
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = HashPassword(request.Password),
                EmployeeId = request.EmployeeId,
                Username = request.Username,
                RoleId = request.RoleId,
                PhoneNumber = request.PhoneNumber,
                DateOfBirth = request.DateOfBirth,
                Address = request.Address,
                City = request.City,
                Country = request.Country,
                ProfilePictureUrl = request.ProfilePictureUrl
            };
        }

        private static string HashPassword(string password)
        {
            var passwordHasher = new PasswordHasher<UserModel>();
            return passwordHasher.HashPassword(null, password);
        }
    }
}
