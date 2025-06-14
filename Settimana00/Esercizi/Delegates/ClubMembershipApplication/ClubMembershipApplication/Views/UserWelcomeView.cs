using ClubMembershipApplication.Common;
using ClubMembershipApplication.Interfaces.Fields;
using ClubMembershipApplication.Interfaces.Views;
using ClubMembershipApplication.Models;
using static ClubMembershipApplication.Models.FieldConstants;

namespace ClubMembershipApplication.Views
{
    public sealed class UserWelcomeView : IView
    {
        private readonly UserDto _user;
        public IFieldValidator FieldValidator => null!;

        public UserWelcomeView(UserDto user)
        {
            _user = user;
        }

        public Task RunView()
        {
            CommonOutputFormat.ChangeFontColor(FontTheme.Success);
            Console.WriteLine($"Hi {_user.FirstName} {_user.LastName}!{Environment.NewLine}Welcome to the Cycling Club.");
            CommonOutputFormat.ChangeFontColor(default);
            Console.ReadKey();
            return Task.CompletedTask;
        }
    }
}