using ClubMembershipApplication.Interfaces.Fields;

namespace ClubMembershipApplication.Interfaces.Views
{
    public interface IView
    {
        Task RunView();
        IFieldValidator FieldValidator { get; }
    }
}
