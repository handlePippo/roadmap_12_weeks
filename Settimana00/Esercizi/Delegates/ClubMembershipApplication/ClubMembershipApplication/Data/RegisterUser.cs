using ClubMembershipApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubMembershipApplication.Data
{
    public sealed class RegisterUser : IRegister
    {
        public async Task<bool> EmailExists(string emailAddress)
        {
            bool emailExists = false;
            using(var dbContext = new ClubMembershipDbContext())
            {
                emailExists = (await dbContext.Users.FirstOrDefaultAsync(u => u.EmailAddress == emailAddress)) != null;
            }
            return await Task.FromResult(emailExists);
        }

        public async Task<bool> Register(UserDto dto)
        {
            using(var dbContext = new ClubMembershipDbContext())
            {
                User user = dto;
                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();
            }
            return await Task.FromResult(true);
        }
    }
}
