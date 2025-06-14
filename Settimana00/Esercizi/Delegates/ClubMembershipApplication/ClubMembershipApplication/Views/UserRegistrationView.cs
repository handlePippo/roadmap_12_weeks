using ClubMembershipApplication.Common;
using ClubMembershipApplication.Interfaces.Application;
using ClubMembershipApplication.Interfaces.Fields;
using ClubMembershipApplication.Interfaces.Views;
using ClubMembershipApplication.Models;
using static ClubMembershipApplication.Models.FieldConstants;

namespace ClubMembershipApplication.Views
{
    public sealed class UserRegistrationView : IView
    {
        private readonly IFieldValidator _fieldValidator;
        private readonly IRegister _register;

        /// <summary>
        /// Field validator
        /// </summary>
        public IFieldValidator FieldValidator { get => _fieldValidator; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="register"></param>
        /// <param name="fieldValidator"></param>
        public UserRegistrationView(IRegister register, IFieldValidator fieldValidator)
        {
            _register = register;
            _fieldValidator = fieldValidator;
        }

        public async Task RunView()
        {
            CommonOutputText.WriteMainHeading();
            CommonOutputText.WriteRegistrationHeading();

            _fieldValidator.FieldsArray[(int)UserRegistrationField.EmailAddress] = GetInputFromUser(UserRegistrationField.EmailAddress, "Please enter your email address");
            _fieldValidator.FieldsArray[(int)UserRegistrationField.FirstName] = GetInputFromUser(UserRegistrationField.FirstName, "Please enter your first name");
            _fieldValidator.FieldsArray[(int)UserRegistrationField.LastName] = GetInputFromUser(UserRegistrationField.LastName, "Please enter your last name");
            _fieldValidator.FieldsArray[(int)UserRegistrationField.Password] = GetInputFromUser(UserRegistrationField.Password, "Please enter your password");
            _fieldValidator.FieldsArray[(int)UserRegistrationField.PasswordCompare] = GetInputFromUser(UserRegistrationField.PasswordCompare, "Please re-enter your password");
            _fieldValidator.FieldsArray[(int)UserRegistrationField.DateOfBirth] = GetInputFromUser(UserRegistrationField.DateOfBirth, "Please enter your date of birth (e.g., 01/31/2000)");
            _fieldValidator.FieldsArray[(int)UserRegistrationField.PhoneNumber] = GetInputFromUser(UserRegistrationField.PhoneNumber, "Please enter your phone number");
            _fieldValidator.FieldsArray[(int)UserRegistrationField.AddressFirstLine] = GetInputFromUser(UserRegistrationField.AddressFirstLine, "Please enter the first line of your address");
            _fieldValidator.FieldsArray[(int)UserRegistrationField.AddressSecondLine] = GetInputFromUser(UserRegistrationField.AddressSecondLine, "Please enter the second line of your address (optional)");
            _fieldValidator.FieldsArray[(int)UserRegistrationField.AddressCity] = GetInputFromUser(UserRegistrationField.AddressCity, "Please enter your city");
            _fieldValidator.FieldsArray[(int)UserRegistrationField.PostCode] = GetInputFromUser(UserRegistrationField.PostCode, "Please enter your post code");

            await RegisterUser();
        }

        private string GetInputFromUser(UserRegistrationField field, string promptText)
        {
            string? fieldValue;

            do
            {
                Console.WriteLine(promptText);
                fieldValue = Console.ReadLine();
            }
            while (!FieldValid(field, fieldValue));

            return fieldValue!;
        }

        private bool FieldValid(UserRegistrationField field, string? fieldValue)
        {
            if (!_fieldValidator.ValidatorDel((int)field, fieldValue!, _fieldValidator.FieldsArray, out var msg))
            {
                CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
                Console.WriteLine(msg);
                CommonOutputFormat.ChangeFontColor(default);
                return false;
            }
            return true;
        }

        private async Task RegisterUser()
        {
            var userDto = new UserDto
            {
                EmailAddress = _fieldValidator.FieldsArray[(int)UserRegistrationField.EmailAddress],
                FirstName = _fieldValidator.FieldsArray[(int)UserRegistrationField.FirstName],
                LastName = _fieldValidator.FieldsArray[(int)UserRegistrationField.LastName],
                Password = _fieldValidator.FieldsArray[(int)UserRegistrationField.Password],
                PasswordCompare = _fieldValidator.FieldsArray[(int)UserRegistrationField.PasswordCompare],
                DateOfBirth = DateTime.Parse(_fieldValidator.FieldsArray[(int)UserRegistrationField.DateOfBirth]),
                PhoneNumber = _fieldValidator.FieldsArray[(int)UserRegistrationField.PhoneNumber],
                AddressFirstLine = _fieldValidator.FieldsArray[(int)UserRegistrationField.AddressFirstLine],
                AddressSecondLine = _fieldValidator.FieldsArray[(int)UserRegistrationField.AddressSecondLine],
                AddressCity = _fieldValidator.FieldsArray[(int)UserRegistrationField.AddressCity],
                PostCode = _fieldValidator.FieldsArray[(int)UserRegistrationField.PostCode],
            };

            User user = userDto;
            var result = await _register.Register(user);

            if(result == true)
            {
                CommonOutputFormat.ChangeFontColor(FontTheme.Success);
                Console.WriteLine("You have successfully registered. Please enter any key to login");
                CommonOutputFormat.ChangeFontColor(default);
                return;
            }
            CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
            Console.WriteLine("Internal error while storing the information. Please try again later");
            CommonOutputFormat.ChangeFontColor(default);
        }
    }
}
