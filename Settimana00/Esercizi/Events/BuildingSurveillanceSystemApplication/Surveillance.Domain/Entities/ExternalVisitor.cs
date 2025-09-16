using Surveillance.Domain.Entities.Base;
using Surveillance.Domain.Various;

namespace Surveillance.Domain.Entities
{
    /// <summary>
    /// Domain entity for ExternalVisitor
    /// </summary>
    public sealed class ExternalVisitor : ObservableEntity<ExternalVisitor>
    {
        public EntityId EmployeeContactId { get; private init; }
        public string FirstName { get; private init; }
        public string LastName { get; private init; }
        public string CompanyName { get; private init; }
        public string JobTitle { get; private init; }
        public DateTimeOffset EntryDateTime { get; private init; }
        public DateTimeOffset? ExitDateTime { get; private set; }
        public bool InBuilding => !ExitDateTime.HasValue;

        private ExternalVisitor(
            EntityId id,
            EntityId employeeContactId,
            string firstName,
            string lastName,
            string companyName,
            string jobTitle,
            DateTimeOffset entryDateTime)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
            EmployeeContactId = employeeContactId ?? throw new ArgumentNullException(nameof(employeeContactId));
            FirstName = Guard(firstName);
            LastName = Guard(lastName);
            CompanyName = Guard(companyName);
            JobTitle = Guard(jobTitle);
            EntryDateTime = entryDateTime;
        }

        public static ExternalVisitor CreateNew(
            EntityId id,
            EntityId employeeContactId,
            string firstName,
            string lastName,
            string companyName,
            string jobTitle,
            DateTimeOffset entryDateTime)
            => new(id, employeeContactId, firstName, lastName, companyName, jobTitle, entryDateTime);


        public void SetExitDateTime(DateTimeOffset exitDateTime)
        {
            if (EntryDateTime >= exitDateTime)
            {
                throw new InvalidOperationException("The entry datetime cannot be greater than the exit datetime.");
            }

            ExitDateTime = exitDateTime;
        }

        private static string Guard(string s) => string.IsNullOrWhiteSpace(s) ? throw new ArgumentException(s) : s.Trim();
    }
}