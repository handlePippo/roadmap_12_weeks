using BuildingSurveillanceSystemApplication.Domain;

namespace BuildingSurveillanceSystemApplication.Dto
{
    public sealed record ExternalVisitorDto
    {
        public string Id { get; private init; } = null!;
        public string EmployeeContactId { get; private init; } = null!;
        public string FirstName { get; private init; } = null!;
        public string LastName { get; private init; } = null!;
        public string CompanyName { get; private init; } = null!;
        public string JobTitle { get; private init; } = null!;
        public DateTime EntryDateTime { get; private set; }
        public DateTime? ExitDateTime { get; private set; }

        public ExternalVisitorDto(string id, string employeeContactId, string firstName, string lastName, string companyName, DateTime entryDateTime)
        {
            Id = id;
            EmployeeContactId = employeeContactId;
            FirstName = firstName;
            LastName = lastName;
            CompanyName = companyName;
            EntryDateTime = entryDateTime;
        }

        public ExternalVisitorDto() { }

        public static implicit operator ExternalVisitorDto(ExternalVisitor externalVisitorDto) => ToExternalVisitorDto(externalVisitorDto);
        public static ExternalVisitor ToExternalVisitorDto(ExternalVisitor externalVisitor)
        {
            ArgumentNullException.ThrowIfNull(externalVisitor);

            var externalVisitorDto = new ExternalVisitorDto
            {
                Id = externalVisitor.Id.Value,
                EmployeeContactId = externalVisitor.EmployeeContactId.Value,
                FirstName = externalVisitor.FirstName,
                LastName = externalVisitor.LastName,
                CompanyName = externalVisitor.CompanyName,
                JobTitle = externalVisitor.JobTitle,
                EntryDateTime = externalVisitor.EntryDateTime,
                ExitDateTime = externalVisitor.ExitDateTime
            };

            return externalVisitor;
        }

        public void SetEntryDateTime(DateTime entryDateTime)
        {
            EntryDateTime = entryDateTime;
        }
    }
}