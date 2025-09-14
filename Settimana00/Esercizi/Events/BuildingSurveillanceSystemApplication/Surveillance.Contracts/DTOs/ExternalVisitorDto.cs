namespace Surveillance.Contracts.DTOs
{
    public sealed record ExternalVisitorDto
    {
        public string Id { get; private init; } = null!;
        public string EmployeeContactId { get; private init; } = null!;
        public string FirstName { get; private init; } = null!;
        public string LastName { get; private init; } = null!;
        public string CompanyName { get; private init; } = null!;
        public string JobTitle { get; private init; } = null!;
        public DateTimeOffset EntryDateTime { get; private set; }
        public DateTimeOffset? ExitDateTime { get; private set; }

        public ExternalVisitorDto(string id, string employeeContactId, string firstName, string lastName, string companyName, DateTime entryDateTime)
        {
            Id = id;
            EmployeeContactId = employeeContactId;
            FirstName = firstName;
            LastName = lastName;
            CompanyName = companyName;
            EntryDateTime = entryDateTime;
        }

        public void SetEntryDateTime(DateTime entryDateTime)
        {
            EntryDateTime = entryDateTime;
        }
    }
}