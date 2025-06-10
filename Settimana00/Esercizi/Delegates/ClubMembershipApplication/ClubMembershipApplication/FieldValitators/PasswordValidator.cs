using ClubMembershipApplication.Models;
using System.Text;

namespace ClubMembershipApplication.FieldValitators
{
    /// <summary>
    /// Password validator
    /// </summary>
    public static class PasswordValidator
    {
        /// <summary>
        /// Hash a password.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string HashPassword(string password)
        => Convert.ToBase64String(Encoding.UTF8.GetBytes(password));

        /// <summary>
        /// Method to determine if two passwords matching or not.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public static bool ArePasswordsMatching(UserDto dto) =>
            dto.Password == dto.PasswordCompare;
    }
}
