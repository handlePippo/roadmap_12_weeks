using static ClubMembershipApplication.Delegates.ClubMembershipSpecificValidationDelegates;

namespace ClubMembershipApplication.FieldValidators
{
    /// <summary>
    /// IFieldValidator
    /// </summary>
    public interface IFieldValidator
    {
        /// <summary>
        /// Definition of a method used to initialize the validator delegates for a particular view.
        /// </summary>
        void InitializeValidatorDelegates();

        /// <summary>
        /// Definition for a readonly property that stores a reference to an array of field values.
        /// </summary>
        string[] FieldsArray { get; }

        /// <summary>
        /// Definition for a readonly property that stores a delegate object that references a method, responsible for validating the fields in a particular view.
        /// </summary>
        FieldValidatorDel ValidatorDel { get; }
    }
}
