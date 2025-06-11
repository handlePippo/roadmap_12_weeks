using ClubMembershipApplication.Models;

namespace ClubMembershipApplication.Data
{
    public interface IRegister
    {
        Task<bool> Register(UserDto dto);
        Task<bool> EmailExists(string emailAddress);
    }
}
