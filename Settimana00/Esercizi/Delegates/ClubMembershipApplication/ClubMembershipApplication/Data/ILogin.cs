using ClubMembershipApplication.Models;

namespace ClubMembershipApplication.Data
{
    public interface ILogin
    {
        User Login(string username, string password);
    }
}
