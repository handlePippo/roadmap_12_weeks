namespace BuildingSurveillanceSystemApplication
{
    public sealed record ExternalVisitor
    {
        public EntityId Id { get; private set; } = null!;
        public EntityId EmployeeContactId { get; private set; } = null!;
        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;
        public string CompanyName { get; private set; } = null!;
        public string JobTitle { get; private set; } = null!;
        public DateTime EntryDateTime { get; private set; }

        public ExternalVisitor(ExternalVisitor externalVisitor)
        {
            Id = externalVisitor.Id;
            EmployeeContactId = externalVisitor.EmployeeContactId;
            FirstName = externalVisitor.FirstName;
            LastName = externalVisitor.LastName;
            CompanyName = externalVisitor.CompanyName;
            JobTitle = externalVisitor.JobTitle;
            EntryDateTime = externalVisitor.EntryDateTime;
        }

        public static implicit operator ExternalVisitor(ExternalVisitorDto externalVisitorDto)
        {
            ArgumentNullException.ThrowIfNull(externalVisitorDto);

            var externalVisitor = new ExternalVisitor();
            externalVisitor.Id = EntityId.Create(externalVisitorDto.Id);
            externalVisitor.EmployeeContactId = EntityId.Create(externalVisitorDto.EmployeeContactId);
            externalVisitor.FirstName = externalVisitorDto.FirstName;
            externalVisitor.LastName = externalVisitorDto.LastName;
            externalVisitor.CompanyName = externalVisitorDto.CompanyName;
            externalVisitor.JobTitle = externalVisitorDto.JobTitle;
            externalVisitor.EntryDateTime = externalVisitorDto.EntryDateTime;

            return externalVisitor;
        }
    }
}