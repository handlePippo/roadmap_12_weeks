namespace FieldValidatorAPI.Delegates
{
    public static class ValidationDelegates
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
    }
}
