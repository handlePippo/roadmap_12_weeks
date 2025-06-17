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
            Console.Clear();
            CommonOutputText.WriteMainHeading();

            CommonOutputFormat.ChangeFontColor(FontTheme.Success);
            Console.WriteLine($"Hi {_user.FirstName} {_user.LastName}!{Environment.NewLine}Welcome to the Cycling Club.");
            CommonOutputFormat.ChangeFontColor(FontTheme.Default);
            Console.WriteLine("You are now authenticated! Press any key to continue.");
            Console.ReadKey();
            return Task.CompletedTask;
        }
    }
}