using ClubMembershipApplication.Models;

namespace ClubMembershipApplication.Interfaces.Application
{
    public interface ILogin
    {
        User Login(string username, string password);
    }
}
