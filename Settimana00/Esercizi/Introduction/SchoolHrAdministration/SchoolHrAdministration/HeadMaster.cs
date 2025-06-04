using HrAdministrationAPI;

namespace SchoolHrAdministration
{
    public sealed class HeadMaster : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary + (base.Salary * 0.05m)); }
    }
}
