using HrAdministrationAPI.Models;

namespace SchoolHrAdministration.Models
{
    public sealed class HeadOfDepartment : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + base.Salary + base.Salary * 0.03m; }
    }
}
