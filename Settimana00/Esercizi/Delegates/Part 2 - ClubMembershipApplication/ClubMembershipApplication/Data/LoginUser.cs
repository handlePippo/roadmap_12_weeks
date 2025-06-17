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
            try
            {
                using (var context = new ClubMembershipDbContext())
                {
                    return await context.Users
                        .FirstOrDefaultAsync(u => u.EmailAddress == emailAddress && u.Password == password);
                }
            }
            catch (Exception ex)
            {
                ex.Data["emailAddress"] = emailAddress;
                ex.Data["password"] = password;
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
