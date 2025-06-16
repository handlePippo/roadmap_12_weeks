namespace ClubMembershipApplication.Models
{
    /// <summary>
    /// Field constants
    /// </summary>
    public static class FieldConstants
    {
        /// <summary>
        /// Enum used to index an array which contains field values for the user's registration form.
        /// </summary>
        public enum UserRegistrationField
        {
            EmailAddress,
            FirstName,
            LastName,
            Password,
            PasswordCompare,
            DateOfBirth,
            PhoneNumber,
            AddressFirstLine,
            AddressSecondLine,
            AddressCity,
            PostCode
        }

        /// <summary>
        /// Enum used to change the font theme
        /// </summary>
        public enum FontTheme
        {
            Default,
            Danger,
            Success
        }
    }
}
