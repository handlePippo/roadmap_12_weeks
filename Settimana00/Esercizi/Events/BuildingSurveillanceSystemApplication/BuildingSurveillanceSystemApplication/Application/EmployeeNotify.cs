using BuildingSurveillanceSystemApplication.Domain;
using BuildingSurveillanceSystemApplication.Domain.Interfaces;

namespace BuildingSurveillanceSystemApplication.Application
{
    public sealed record EmployeeNotify : IObserver<ExternalVisitor>
    {
        public EmployeeNotify(IEmployee employee)
        {

        }

        public void OnCompleted()
        {
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