using Surveillance.Domain;
using Surveillance.Domain.Interfaces;

namespace Surveillance.Application
{
    public sealed record EmployeeNotify : IObserver<ExternalVisitor>
    {
        private readonly IEmployee _employee;
        public EmployeeNotify(IEmployee employee)
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
            throw new NotImplementedException();
        }
    }
}