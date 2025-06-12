using ClubMembershipApplication.Models;

namespace ClubMembershipApplication.Interfaces.Application
{
    public interface IRegister
    {
        Task<bool> Register(User dto);
        bool EmailExists(string emailAddress);
    }
}
