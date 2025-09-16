using Surveillance.Domain.Entities;
using Surveillance.Domain.Interfaces;

namespace Surveillance.Application.Implementations
{
    public sealed record EmployeeNotify : IObserver<ExternalVisitor>
    {
        private readonly IEmployee _employee;
        private readonly IList<ExternalVisitor> _externalVisitors = [];

        public EmployeeNotify(IEmployee employee, IList<ExternalVisitor> externalVisitors)
        {
            _employee = employee ?? throw new ArgumentNullException(nameof(employee));
        }

        public void OnCompleted()
        {
            _employee.GetHashCode(); // Tbd
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(ExternalVisitor value)
        {
            var externalVisitor = value;

            if (externalVisitor.EmployeeContactId.Value == ((IEntityBase)_employee).Id.Value)
            {
                var externalVisitorListItem = _externalVisitors.FirstOrDefault(e => e.Id.Value == externalVisitor.Id.Value);
                if (externalVisitorListItem is null)
                {
                    _externalVisitors.Add(externalVisitor);

                    Console.WriteLine($"{_employee.FirstName} {_employee.LastName}, your visitor has arrived. Visitor Id {externalVisitor.Id.Value}, FirstName {externalVisitor.FirstName} LastName {externalVisitor.LastName}, entered the building. DateTime {externalVisitor.EntryDateTime:dd MM yyyy hh:mm:ss}");
                    return;
                }

                if (!externalVisitor.InBuilding)
                {
                    externalVisitorListItem.SetExitDateTime(externalVisitor.ExitDateTime!.Value);
                }
            }
        }
    }
}