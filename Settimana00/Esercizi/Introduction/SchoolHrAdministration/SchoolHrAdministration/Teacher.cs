using HrAdministrationAPI;

namespace SchoolHrAdministration
{
    public sealed class Teacher : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary + (base.Salary * 0.02m)); }
    }
}
