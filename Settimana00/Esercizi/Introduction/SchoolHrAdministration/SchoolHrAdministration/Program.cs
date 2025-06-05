using HrAdministrationAPI.Models;
using SchoolHrAdministration.Models;

namespace SchoolHrAdministration
{
    internal class Program
    {
        static void Main(string[] _)
        {
            List<IEmployee> employees = new List<IEmployee>();
            SeedData(employees);

            #region UnworthApproach

            //decimal totalSalaries = 0;
            //foreach (IEmployee employee in employees)
            //{
            //    totalSalaries += employee.Salary;
            //}

            //Console.WriteLine("Total annual salaries (Including bonus): " + totalSalaries);

            #endregion

            Console.WriteLine("Total annual salaries (Including bonus): " + employees.Sum(e => e.Salary));

            Console.ReadKey();
        }

        public static void SeedData(List<IEmployee> employees)
        {
            IEmployee teacher1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 1, "Bob", "Fisher", 40000);
            employees.Add(teacher1);

            IEmployee teacher2 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 2, "Jenny", "Thomas", 40000);
            employees.Add(teacher2);

            IEmployee headOfDep = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 3, "Brenda", "Mullins", 50000);
            employees.Add(headOfDep);

            IEmployee deputyHeadMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 4, "Devin", "Brown", 60000);
            employees.Add(deputyHeadMaster);

            IEmployee headMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadMaster, 5, "Damien", "Jones", 80000);
            employees.Add(headMaster);
        }
    }
}
