using System.Collections.ObjectModel;

namespace EmployeeComponent
{
    public sealed class Employees
    {
        public static ObservableCollection<EmployeeViewModel> GetEmployees()
        {
            var employees = new ObservableCollection<EmployeeViewModel>
            {
                new EmployeeViewModel
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Green",
                    AnnualSalary = 40000,
                    Gender = 'm'
                },
                new EmployeeViewModel
                {
                    Id = 2,
                    FirstName = "Sally",
                    LastName = "Jones",
                    AnnualSalary = 55000,
                    Gender = 'f'
                },
                new EmployeeViewModel
                {
                    Id = 3,
                    FirstName = "Bill",
                    LastName = "Blog",
                    AnnualSalary = 30000,
                    Gender = 'm'
                },
                new EmployeeViewModel
                {
                    Id = 4,
                    FirstName = "Jamie",
                    LastName = "Hopkins",
                    AnnualSalary = 80000,
                    Gender = 'm'
                }
            };

            return employees;
        }
    }
}