using HrAdministrationAPI.Models;

namespace SchoolHrAdministration.Models
{
    public sealed class HeadMaster : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + base.Salary + base.Salary * 0.05m; }
    }
}
