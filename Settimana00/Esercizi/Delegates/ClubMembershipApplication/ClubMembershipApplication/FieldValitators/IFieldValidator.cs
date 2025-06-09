namespace ClubMembershipApplication.FieldValitators
{
    public delegate bool FieldValidatorDel(int fieldIndex, string field, string[] fields, out string fieldInvalidMessage);
    
    /// <summary>
    /// IFieldValidator
    /// </summary>
    public interface IFieldValidator
    {
        /// <summary>
        /// Definition of a method used to initialize the validator delegates
        /// </summary>
        void InitializeValidatorDelegates();

        /// <summary>
        /// Definition for a readonly array that stores fields
        /// </summary>
        string[] FieldsArray { get; }

        /// <summary>
        /// Definition for a readonly property that stores a delegate object that references a method, responsible for validating the fields in a partical view
        /// </summary>
        FieldValidatorDel ValidatorDel { get; }
    }
}
