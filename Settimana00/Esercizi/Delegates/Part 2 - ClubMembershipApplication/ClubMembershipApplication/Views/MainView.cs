using ClubMembershipApplication.Common;
using ClubMembershipApplication.Interfaces.Fields;
using ClubMembershipApplication.Interfaces.Views;

namespace ClubMembershipApplication.Views
{
    public sealed class MainView : IView
    {
        private const int LIMIT = 3;
        private readonly IView _registrationView;
        private readonly IView _loginView;

        public IFieldValidator FieldValidator => null!;

        public int counter = 0;

        public MainView(IView registrationView, IView loginView)
        {
            _registrationView = registrationView;
            _loginView = loginView;
        }

        public Task RunView()
        {
            if (counter == LIMIT)
            {
                Console.WriteLine("3 sequence fail. Please try later");
                return Task.CompletedTask;
            }

            CommonOutputText.WriteMainHeading();
            Console.WriteLine("Press the 'L' key to login, the 'R' key to register or any other key to quit the application");
            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.R:
                    _registrationView.RunView();
                    _loginView.RunView();
                    break;
                case ConsoleKey.L:
                    _loginView.RunView();
                    break;
                default:
                    Console.WriteLine("Goodbye!");
                    break;
            }

            return Task.CompletedTask;
        }
    }
}
