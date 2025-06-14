using ClubMembershipApplication.Interfaces.Application;
using ClubMembershipApplication.Models;

namespace ClubMembershipApplication.Data
{
    /// <summary>
    /// User registration
    /// </summary>
    public sealed class RegisterUser : IRegister
    {
        public bool EmailExists(string emailAddress)
        {
            bool emailExists = false;
            using (var dbContext = new ClubMembershipDbContext())
            {
                emailExists = dbContext.Users.FirstOrDefault(u => u.EmailAddress == emailAddress) != null;
            }
            return emailExists;
        }

        public async Task<bool> Register(User user)
        {
            using (var dbContext = new ClubMembershipDbContext())
            {
                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();
            }
            return await Task.FromResult(true);
        }
    }
}
