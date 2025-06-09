using ClubMembershipApplication.Models;
using System.Text;

namespace ClubMembershipApplication.FieldValitators
{
    public static class PasswordValidator
    {
        public static string HashPassword(string password)
        => Convert.ToBase64String(Encoding.UTF8.GetBytes(password));

        public static bool ArePasswordsMatching(UserDto dto) =>
            dto.Password == dto.PasswordCompare;
    }
}
