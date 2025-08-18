namespace EmployeeComponent
{
    public static class EmployeeFactory
    {
        public static EmployeeViewModel Create(int id, string firstName, string lastName, decimal annualSalary, char gender)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(firstName);
            ArgumentException.ThrowIfNullOrWhiteSpace(lastName);

            return new EmployeeViewModel(id, firstName, lastName, annualSalary, gender);
        }
    }
}