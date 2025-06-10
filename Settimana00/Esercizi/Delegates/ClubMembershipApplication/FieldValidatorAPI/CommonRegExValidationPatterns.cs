namespace FieldValidatorAPI
{
    /// <summary>
    /// Common RegEx validation patterns
    /// </summary>
    public static class CommonRegExValidationPatterns
    {
        public const string Email_Address_RegEx_Pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        public const string Uk_PhoneNumber_RegEx_Pattern = @"^(\+44\s?|0044\s?|0)?7\d{3}[\s.-]?\d{6}$";
        public const string Uk_PostCode_RegEx_Pattern = @"^(?i)(GIR\s?0AA|[A-Z]{1,2}\d{1,2}[A-Z]?\s?\d[A-Z]{2})$";
        public const string Strong_Password_RegEx_Pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#+=^])[A-Za-z\d@$!%*?&#+=^]{12,}$";
    }
}
