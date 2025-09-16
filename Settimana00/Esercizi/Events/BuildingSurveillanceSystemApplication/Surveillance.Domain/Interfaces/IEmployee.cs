namespace Surveillance.Domain.Interfaces
{
    /// <summary>
    /// Contracts for IEmployee.
    /// </summary>
    public interface IEmployee
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
    }
}