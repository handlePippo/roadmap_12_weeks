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
            try
            {
                bool emailExists = false;
                using (var dbContext = new ClubMembershipDbContext())
                {
                    emailExists = dbContext.Users.FirstOrDefault(u => u.EmailAddress == emailAddress) != null;
                }
                return emailExists;
            }
            catch (Exception ex)
            {
                ex.Data["emailAddress"] = emailAddress;
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<bool> Register(User user)
        {
            try
            {
                using (var dbContext = new ClubMembershipDbContext())
                {
                    await dbContext.Users.AddAsync(user);
                    await dbContext.SaveChangesAsync();
                }
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                ex.Data["user"] = user;
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
