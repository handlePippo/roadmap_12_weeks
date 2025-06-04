using HrAdministrationAPI;

namespace SchoolHrAdministration
{
    public sealed class DeputyHeadMaster : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary + (base.Salary * 0.04m)); }
    }
}
