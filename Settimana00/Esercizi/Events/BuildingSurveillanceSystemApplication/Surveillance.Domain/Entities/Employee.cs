using Surveillance.Domain.Entities.Base;
using Surveillance.Domain.Interfaces;

namespace Surveillance.Domain.Entities
{
    public sealed class Employee : ObserverEntity<Employee>, IEmployee
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}