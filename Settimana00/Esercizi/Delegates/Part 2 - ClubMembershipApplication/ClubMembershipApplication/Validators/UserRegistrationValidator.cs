using ClubMembershipApplication.Interfaces.Application;
using ClubMembershipApplication.Interfaces.Fields;
using ClubMembershipApplication.Models;
using FieldValidatorAPI;
using static ClubMembershipApplication.Models.Delegates.ClubMembershipSpecificValidationDelegates;
using static FieldValidatorAPI.Delegates.CommonValidationDelegates;

namespace ClubMembershipApplication.Validators
{
    public sealed class UserRegistrationValidator : IFieldValidator
    {
        private const int FirstName_Min_Length = 2;
        private const int FirstName_Max_Length = 100;
        private const int LastName_Min_Length = 2;
        private const int LastName_Max_Length = 100;

        private static RequiredValidDelegate _requiredFieldValidDelegate = null!;
        private static StringLengthValidDelegate _stringLengthValidDelegate = null!;
        private static DateValidDelegate _dateValidDelegate = null!;
        private static PatternMatchValidDelegate _patternMatchDelegate = null!;
        private static CompareFieldsValidDelegate _compareFieldsValidDelegate = null!;

        private static EmailExistsDelegate _emailExistsDelegate = null!;
        private static FieldValidatorDel _fieldValidatorDel = null!;

        private string[] _fieldArray = null!;
        private readonly IRegister _register;

        public string[] FieldsArray
        {
            get
            {
                if (_fieldArray is null)
                {
                    _fieldArray = new string[Enum.GetValues(typeof(FieldConstants.UserRegistrationField)).Length];
                }
                return _fieldArray;
            }
        }

        public FieldValidatorDel ValidatorDel
        {
            get
            {
                return _fieldValidatorDel;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public UserRegistrationValidator(IRegister register)
        {
            _register = register;
        }

        public void InitializeValidatorDelegates()
        {
            _fieldValidatorDel = new FieldValidatorDel(ValidateField);
            _emailExistsDelegate = new EmailExistsDelegate(_register.EmailExists);

            _requiredFieldValidDelegate = CommonFieldValitatorFunctions.RequiredFieldValidDelegate;
            _stringLengthValidDelegate = CommonFieldValitatorFunctions.StringFieldLengthValidDelegate;
            _dateValidDelegate = CommonFieldValitatorFunctions.DateFieldValidDelegate;
            _patternMatchDelegate = CommonFieldValitatorFunctions.PatternFieldValidDelegate;
            _compareFieldsValidDelegate = CommonFieldValitatorFunctions.ComparisonFieldValidDelegate;

        }

        private static bool ValidateField(int fieldIndex, string field, string[] fields, out string fieldInvalidMessage)
        {
            fieldInvalidMessage = string.Empty;

            FieldConstants.UserRegistrationField userRegistrationField = (FieldConstants.UserRegistrationField)fieldIndex;

            string fieldName = Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)
                ?? throw new NullReferenceException($"Property {userRegistrationField} not present in {nameof(FieldConstants.UserRegistrationField)} enumerator");

            switch (userRegistrationField)
            {
                case FieldConstants.UserRegistrationField.EmailAddress:
                    if (!_requiredFieldValidDelegate(field))
                    {
                        fieldInvalidMessage = $"You must enter a value for field: {fieldName}{Environment.NewLine}";
                    }
                    if (fieldInvalidMessage == string.Empty && !_patternMatchDelegate(field, CommonRegExValidationPatterns.Email_Address_RegEx_Pattern))
                    {
                        fieldInvalidMessage = $"You must enter a valid email address{Environment.NewLine}";
                    }
                    if (fieldInvalidMessage == string.Empty && _emailExistsDelegate(field))
                    {
                        fieldInvalidMessage = $"This email address already exists{Environment.NewLine}";
                    }
                    break;
                case FieldConstants.UserRegistrationField.FirstName:
                    if (!_requiredFieldValidDelegate(field))
                    {
                        fieldInvalidMessage = $"You must enter a value for field: {fieldName}{Environment.NewLine}";
                    }
                    if (fieldInvalidMessage == string.Empty && !_stringLengthValidDelegate(field, FirstName_Min_Length, FirstName_Max_Length))
                    {
                        fieldInvalidMessage = $"{fieldName} must be between {FirstName_Min_Length} and {FirstName_Max_Length} chars{Environment.NewLine}";
                    }
                    break;
                case FieldConstants.UserRegistrationField.LastName:
                    if (!_requiredFieldValidDelegate(field))
                    {
                        fieldInvalidMessage = $"You must enter a value for field: {fieldName}{Environment.NewLine}";
                    }
                    if (fieldInvalidMessage == string.Empty && !_stringLengthValidDelegate(field, LastName_Min_Length, LastName_Max_Length))
                    {
                        fieldInvalidMessage = $"{fieldName} must be between {LastName_Min_Length} and {LastName_Max_Length} chars{Environment.NewLine}";
                    }
                    break;
                case FieldConstants.UserRegistrationField.Password:
                    if (!_requiredFieldValidDelegate(field))
                    {
                        fieldInvalidMessage = $"You must enter a value for field: {fieldName}{Environment.NewLine}";
                    }
                    if (fieldInvalidMessage == string.Empty && !_patternMatchDelegate(field, CommonRegExValidationPatterns.Strong_Password_RegEx_Pattern))
                    {
                        fieldInvalidMessage = $"{fieldName} must be a valid password, with a length of at least 12 characters and must contain at least 1 number, 1 capital letter, and 1 special character{Environment.NewLine}";
                    }
                    break;
                case FieldConstants.UserRegistrationField.PasswordCompare:
                    if (!_requiredFieldValidDelegate(field))
                    {
                        fieldInvalidMessage = $"You must enter a value for field: {fieldName}{Environment.NewLine}";
                    }
                    if (fieldInvalidMessage == string.Empty)
                    {
                        if (fields[(int)FieldConstants.UserRegistrationField.Password] is null)
                        {
                            throw new InvalidOperationException("PasswordCompare must only set after Password!");
                        }
                        if (!_compareFieldsValidDelegate(field, fields[(int)FieldConstants.UserRegistrationField.Password]))
                        {
                            fieldInvalidMessage = $"Your entry did not match your password{Environment.NewLine}";
                        }
                    }
                    break;
                case FieldConstants.UserRegistrationField.DateOfBirth:
                    if (!_requiredFieldValidDelegate(field))
                    {
                        fieldInvalidMessage = $"You must enter a value for field: {fieldName}{Environment.NewLine}";
                    }
                    if (fieldInvalidMessage == string.Empty && !_dateValidDelegate(field, out DateTime validDateTime))
                    {
                        fieldInvalidMessage = $"You did not enter a valid date{Environment.NewLine}";
                    }
                    break;
                case FieldConstants.UserRegistrationField.PhoneNumber:
                    if (!_requiredFieldValidDelegate(field))
                    {
                        fieldInvalidMessage = $"You must enter a value for field: {fieldName}{Environment.NewLine}";
                    }
                    if (fieldInvalidMessage == string.Empty && !_patternMatchDelegate(field, CommonRegExValidationPatterns.Uk_PhoneNumber_RegEx_Pattern))
                    {
                        fieldInvalidMessage = $"{field} is not a valid UK phone number{Environment.NewLine}";
                    }
                    break;
                case FieldConstants.UserRegistrationField.AddressFirstLine:
                    if (!_requiredFieldValidDelegate(field))
                    {
                        fieldInvalidMessage = $"You must enter a value for field: {fieldName}{Environment.NewLine}";
                    }
                    break;
                case FieldConstants.UserRegistrationField.AddressSecondLine:
                    break;
                case FieldConstants.UserRegistrationField.AddressCity:
                    if (!_requiredFieldValidDelegate(field))
                    {
                        fieldInvalidMessage = $"You must enter a value for field: {fieldName}{Environment.NewLine}";
                    }
                    break;
                case FieldConstants.UserRegistrationField.PostCode:
                    if (!_requiredFieldValidDelegate(field))
                    {
                        fieldInvalidMessage = $"You must enter a value for field: {fieldName}{Environment.NewLine}";
                    }
                    if (fieldInvalidMessage == string.Empty && !_patternMatchDelegate(field, CommonRegExValidationPatterns.Uk_PostCode_RegEx_Pattern))
                    {
                        fieldInvalidMessage = $"{field} is not a valid UK post code{Environment.NewLine}";
                    }
                    break;
                default:
                    throw new ArgumentException($"Field {field} does not exist");
            }

            return fieldInvalidMessage == string.Empty;
        }
    }
}
