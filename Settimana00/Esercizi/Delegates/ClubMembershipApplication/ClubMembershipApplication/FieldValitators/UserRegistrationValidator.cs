using FieldValidatorAPI;
using static ClubMembershipApplication.Delegates.ClubMembershipSpecificValidationDelegates;
using static FieldValidatorAPI.Delegates.CommonValidationDelegates;

namespace ClubMembershipApplication.FieldValitators
{
    public class UserRegistrationValidator : IFieldValidator
    {
        private const int FirstName_Min_Length = 2;
        private const int FirstName_Max_Length = 100;
        private const int LastName_Min_Length = 2;
        private const int LastName_Max_Length = 100;

        private static RequiredValidDelegate _requiredFieldValidDelegate = null!;
        private static StringLengthValidDelegate _stringLengthValidDelegate = null!;
        private static DateValidDelegate _dateValidDelegate = null!;
        private static PatternMatchDelegate _patternMatchDelegate = null!;
        private static CompareFieldsValidDelegate _compareFieldsValidDelegate = null!;

        private static EmailExistsDelegate _emailExistsDelegate = null!;

        private static FieldValidatorDel _fieldValidatorDel = null!;

        private string[] _fieldArray = null!;

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

        public void InitializeValidatorDelegates()
        {
            _requiredFieldValidDelegate = CommonFieldValitatorFunctions.RequiredFieldValidDelegate;
            _stringLengthValidDelegate = CommonFieldValitatorFunctions.StringFieldLengthValidDelegate;
            _dateValidDelegate = CommonFieldValitatorFunctions.DateFieldValidDelegate;
            _patternMatchDelegate = CommonFieldValitatorFunctions.PatternFieldValidDelegate;
            _compareFieldsValidDelegate = CommonFieldValitatorFunctions.ComparisonFieldValidDelegate;

            _fieldValidatorDel = new FieldValidatorDel(ValidateField);
        }

        private static bool ValidateField(int fieldIndex, string field, string[] fields, out string fieldInvalidMessage)
        {
            fieldInvalidMessage = string.Empty;

            FieldConstants.UserRegistrationField userRegistrationField = (FieldConstants.UserRegistrationField)fieldIndex;

            switch (userRegistrationField)
            {
                case FieldConstants.UserRegistrationField.EmailAddress:
                    if (!_fieldValidatorDel(fieldIndex, field, fields, out fieldInvalidMessage))
                    {
                        fieldInvalidMessage = $"You must enter a value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationField), userRegistrationField)}{Environment.NewLine}";
                    }
                    if (fieldInvalidMessage == string.Empty && !_patternMatchDelegate(field, CommonRegExValidationPatterns.Email_Address_RegEx_Pattern))
                    {
                        fieldInvalidMessage = $"You must enter a valid email address{Environment.NewLine}";
                    }
                    break;
                default:
                    break;
            }

            return (fieldInvalidMessage == string.Empty);
        }
    }
}
