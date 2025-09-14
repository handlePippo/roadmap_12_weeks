using Surveillance.Contracts.DTOs;
using Surveillance.Domain;

namespace Surveillance.Application.Factories;

internal static class ExternalVisitorFactory
{
    internal static ExternalVisitor Map(ExternalVisitorDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto);

        return ExternalVisitor.CreateNew(
            id: EntityId.Create(dto.Id),
            employeeContactId: EntityId.Create(dto.EmployeeContactId),
            firstName: dto.FirstName,
            lastName: dto.LastName,
            companyName: dto.CompanyName,
            jobTitle: dto.JobTitle,
            entryDateTime: dto.EntryDateTime
        );
    }
}
