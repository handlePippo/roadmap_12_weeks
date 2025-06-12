using System.Text.RegularExpressions;
using static FieldValidatorAPI.Delegates.CommonValidationDelegates;

namespace FieldValidatorAPI
{
    /// <summary>
    /// Common validator functions
    /// </summary>
    public static class CommonFieldValitatorFunctions
    {
        private static RequiredValidDelegate _requiredValidDelegate = null!;
        private static StringLengthValidDelegate _stringLengthValidDelegate = null!;
        private static DateValidDelegate _dateValidDelegate = null!;
        private static PatternMatchDelegate _patternMatchDelegate = null!;
        private static CompareFieldsValidDelegate _compareFieldsValidDelegate = null!;

        /// <summary>
        /// RequiredFieldValidDelegate
        /// </summary>
        public static RequiredValidDelegate RequiredFieldValidDelegate
        {
            get
            {
                if (_requiredValidDelegate is null)
                {
                    _requiredValidDelegate = new RequiredValidDelegate(RequiredFieldValid);
                }
                return _requiredValidDelegate;
            }
        }

        /// <summary>
        /// StringFieldLengthValidDelegate
        /// </summary>
        public static StringLengthValidDelegate StringFieldLengthValidDelegate
        {
            get
            {
                if (_stringLengthValidDelegate is null)
                {
                    _stringLengthValidDelegate = new StringLengthValidDelegate(StringFieldLengthValid);
                }
                return _stringLengthValidDelegate;
            }
        }

        /// <summary>
        /// DateFieldValidDelegate
        /// </summary>
        public static DateValidDelegate DateFieldValidDelegate
        {
            get
            {
                if (_dateValidDelegate is null)
                {
                    _dateValidDelegate = new DateValidDelegate(DateFieldValid);
                }
                return _dateValidDelegate;
            }
        }

        /// <summary>
        /// PatternFieldValidDelegate
        /// </summary>
        public static PatternMatchDelegate PatternFieldValidDelegate
        {
            get
            {
                if (_patternMatchDelegate is null)
                {
                    _patternMatchDelegate = new PatternMatchDelegate(PatternFieldValid);
                }
                return _patternMatchDelegate;
            }
        }

        /// <summary>
        /// ComparisonFieldValidDelegate
        /// </summary>
        public static CompareFieldsValidDelegate ComparisonFieldValidDelegate
        {
            get
            {
                if (_compareFieldsValidDelegate is null)
                {
                    _compareFieldsValidDelegate = new CompareFieldsValidDelegate(ComparisonFieldValid);
                }
                return _compareFieldsValidDelegate;
            }
        }

        #region private methods

        private static bool RequiredFieldValid(string fieldValue)
        {
            return !string.IsNullOrWhiteSpace(fieldValue);
        }

        private static bool StringFieldLengthValid(string fieldValue, int min, int max)
        {
            return RequiredFieldValid(fieldValue) && fieldValue.Length >= min && fieldValue.Length <= max;
        }

        private static bool DateFieldValid(string fieldValue, out DateTime validDateTime)
        {
            return DateTime.TryParse(fieldValue, out validDateTime);
        }

        private static bool PatternFieldValid(string fieldValue, string pattern)
        {
            return Regex.IsMatch(fieldValue, pattern);
        }

        private static bool ComparisonFieldValid(string fieldValue, string fieldValueCompare)
        {
            return RequiredFieldValid(fieldValue) && RequiredFieldValid(fieldValueCompare) && fieldValue.Equals(fieldValueCompare);
        }

        #endregion
    }
}