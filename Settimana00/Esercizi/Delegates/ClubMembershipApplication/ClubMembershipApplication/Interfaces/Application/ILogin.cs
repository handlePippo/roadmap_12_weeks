using ClubMembershipApplication.Models;

namespace ClubMembershipApplication.Interfaces.Application
{
    /// <summary>
    /// User login
    /// </summary>
    public interface ILogin
    {
        /// <summary>
        /// Method to login the user into the system.
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="password"></param>
        /// <returns>the requested user, if found on the system.</returns>
        Task<User?> Login(string emailAddress, string password);
    }
}
