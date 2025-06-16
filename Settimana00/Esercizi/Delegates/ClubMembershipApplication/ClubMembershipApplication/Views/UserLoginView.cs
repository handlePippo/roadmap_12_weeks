using ClubMembershipApplication.Common;
using ClubMembershipApplication.Interfaces.Application;
using ClubMembershipApplication.Interfaces.Fields;
using ClubMembershipApplication.Interfaces.Views;
using ClubMembershipApplication.Models;
using FieldValidatorAPI;
using static ClubMembershipApplication.Models.FieldConstants;
using static FieldValidatorAPI.Delegates.CommonValidationDelegates;

namespace ClubMembershipApplication.Views
{
    public sealed class UserLoginView : IView
    {
        private readonly ILogin _login;
        private readonly RequiredValidDelegate _requiredValidDelegate;

        public IFieldValidator FieldValidator => null!;

        public UserLoginView(ILogin login)
        {
            _login = login;
            _requiredValidDelegate = CommonFieldValitatorFunctions.RequiredFieldValidDelegate;
        }

        public async Task RunView()
        {
            CommonOutputText.WriteMainHeading();
            CommonOutputText.WriteLoginHeading();

            string? emailAddress;
            do
            {
                Console.Write("Please enter your email address: ");
                emailAddress = Console.ReadLine();
            }
            while (!_requiredValidDelegate(emailAddress));

            string? password;
            do
            {
                Console.Write("Please enter your email password: ");
                password = Console.ReadLine();
            }
            while (!_requiredValidDelegate(password));

            var user = await _login.Login(emailAddress!, password!);

            if (user is not null)
            {
                UserDto dto = user;
                UserWelcomeView userWelcomeView = new UserWelcomeView(dto);
                await userWelcomeView.RunView();
                return;
            }

            Console.Clear();
            CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
            Console.WriteLine("The credentials that you entered does not match any existing record");
            CommonOutputFormat.ChangeFontColor(FontTheme.Default);
            Console.ReadKey();
        }
    }
}
