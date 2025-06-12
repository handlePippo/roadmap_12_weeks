namespace ClubMembershipApplication.Models.Delegates
{
    public static class ClubMembershipSpecificValidationDelegates
    {
        public delegate bool FieldValidatorDel(int fieldIndex, string field, string[] fields, out string fieldInvalidMessage);

        internal delegate bool EmailExistsDelegate(string emailAddress);
    }
}
