using System.Text.RegularExpressions;

namespace FieldValidatorAPI
{
    /// <summary>
    /// Validation of required field
    /// </summary>
    /// <param name="fieldValue"></param>
    /// <returns></returns>
    public delegate bool RequiredValidDelegate(string fieldValue);

    /// <summary>
    /// Validation of the length of a given string
    /// </summary>
    /// <param name="fieldValue"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public delegate bool StringLengthValidDelegate(string fieldValue, int min, int max);

    /// <summary>
    /// Validation of a given date
    /// </summary>
    /// <param name="fieldValue"></param>
    /// <param name="validDateTime"></param>
    /// <returns></returns>
    public delegate bool DateValidDelegate(string fieldValue, out DateTime validDateTime);

    /// <summary>
    /// Validation of a given pattern
    /// </summary>
    /// <param name="fieldValue"></param>
    /// <param name="pattern"></param>
    /// <returns></returns>
    public delegate bool PatternMatchDelegate(string fieldValue, string pattern);

    /// <summary>
    /// Validation between two fields
    /// </summary>
    /// <param name="fieldValue"></param>
    /// <param name="fieldValueCompare"></param>
    /// <returns></returns>
    public delegate bool CompareFieldsValidDelegate(string fieldValue, string fieldValueCompare);

    /// <summary>
    /// Common validator functions
    /// </summary>
    public sealed class CommonFieldValitatorFunctions
    {
        private static RequiredValidDelegate _requiredValidDelegate = null!;
        private static StringLengthValidDelegate _stringLengthValidDelegate = null!;
        private static DateValidDelegate _dateValidDelegate = null!;
        private static PatternMatchDelegate _patternMatchDelegate = null!;
        private static CompareFieldsValidDelegate _compareFieldsValidDelegate = null!;

        public static RequiredValidDelegate RequiredFieldValidDelegate
        {
            get
            {
                if(_requiredValidDelegate is null)
                {
                    _requiredValidDelegate = new RequiredValidDelegate(RequiredFieldValid);
                }
                return _requiredValidDelegate;
            }
        }

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
    }
}