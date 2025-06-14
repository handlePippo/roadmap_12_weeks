using ClubMembershipApplication.Interfaces.Application;
using ClubMembershipApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubMembershipApplication.Data
{
    /// <summary>
    /// User login
    /// </summary>
    public sealed class LoginUser : ILogin
    {
        public async Task<User?> Login(string emailAddress, string password)
        {
            using (var context = new ClubMembershipDbContext())
            {
                return await context.Users
                    .FirstOrDefaultAsync(u => u.EmailAddress
                        .Equals(emailAddress, StringComparison.OrdinalIgnoreCase) && u.Password
                        .Equals(password, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
