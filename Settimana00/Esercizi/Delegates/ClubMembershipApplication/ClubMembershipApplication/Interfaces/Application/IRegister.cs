using ClubMembershipApplication.Models;

namespace ClubMembershipApplication.Interfaces.Application
{
    public interface IRegister
    {
        /// <summary>
        /// Method to register the user into the system.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>true or false.</returns>
        Task<bool> Register(User dto);

        /// <summary>
        /// Method to check if the user's email already exists.
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns>true or false.</returns>
        bool EmailExists(string emailAddress);
    }
}
