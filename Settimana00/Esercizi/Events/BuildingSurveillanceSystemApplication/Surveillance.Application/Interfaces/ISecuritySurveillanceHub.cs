using Surveillance.Contracts.DTOs;
using Surveillance.Domain.Various;

namespace Surveillance.Application.Interfaces
{
    public interface ISecuritySurveillanceHub
    {
        void ConfirmExternalVisitorEntersBuilding(ExternalVisitorDto externalVisitorDto);
        void ConfirmExternalVisitorExitsBuilding(EntityId externalVisitorId, DateTime exitDateTime);
        void BuildingEntryCutOffTimeReached();
    }
}
