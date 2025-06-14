using ClubMembershipApplication.Data;
using ClubMembershipApplication.Interfaces.Application;
using ClubMembershipApplication.Interfaces.Fields;
using ClubMembershipApplication.Interfaces.Views;
using ClubMembershipApplication.Validators;
using ClubMembershipApplication.Views;

namespace ClubMembershipApplication.Factories
{
    /// <summary>
    /// View factory
    /// </summary>
    public static class ViewFactory
    {
        /// <summary>
        /// Method to abstract the main view object creation.
        /// </summary>
        /// <returns>the main view object.</returns>
        public static IView GetMainViewObject()
        {
            ILogin login = new LoginUser();
            IRegister register = new RegisterUser();
            IFieldValidator fieldValidator = new UserRegistrationValidator(register);
            fieldValidator.InitializeValidatorDelegates();

            IView registrationView = new UserRegistrationView(register, fieldValidator);
            IView loginView = new UserLoginView(login);

            return new MainView(registrationView, loginView);
        }
    }
}