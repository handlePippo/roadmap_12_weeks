namespace Func_Action_Predicate
{
    internal class Program
    {
        static void Main(string[] _)
        {
            // Func
            Func<decimal, decimal, decimal> calculateTotalAnnualSalary = (annualSalary, bonusPercentage) => annualSalary + (annualSalary * bonusPercentage / 100);

            // Action
            Action<int, string, string, decimal, char, bool> displayEmployeeRecords = (arg1, arg2, arg3, arg4, arg5, arg6)
                => Console.WriteLine($"Id: {arg1}{Environment.NewLine}First Name: {arg2}{Environment.NewLine}Last Name:{arg3}{Environment.NewLine}Salary: {arg4}{Environment.NewLine}Gender: {arg5}{Environment.NewLine}Manager: {arg6}{Environment.NewLine}");

            //Predicate
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    FirstName = "Sarah",
                    LastName = "Jones",
                    Salary = calculateTotalAnnualSalary(40000, 2),
                    Gender = 'F',
                    Manager = false
                },
                new Employee
                {
                    Id = 1,
                    FirstName = "Mark",
                    LastName = "Slice",
                    Salary = calculateTotalAnnualSalary(64000, 3),
                    Gender = 'M',
                    Manager = true
                },
                new Employee
                {
                    Id = 1,
                    FirstName = "Oliver",
                    LastName = "Benson",
                    Salary = calculateTotalAnnualSalary(35500, 2),
                    Gender = 'M',
                    Manager = false
                },
                new Employee
                {
                    Id = 1,
                    FirstName = "Monica",
                    LastName = "Treccani",
                    Salary = calculateTotalAnnualSalary(90000, 4),
                    Gender = 'F',
                    Manager = true
                },
            };

            var employeesFiltered = employees.FilterEmployees(e => e.Salary < 45000);
            //var employeesFiltered = employees.Where(e => e.Manager == true); // The same with LINQ built-in Where
            foreach (var filteredEmployee in employeesFiltered)
            {
                displayEmployeeRecords(filteredEmployee.Id, filteredEmployee.FirstName, filteredEmployee.LastName, filteredEmployee.Salary, filteredEmployee.Gender, filteredEmployee.Manager);
            }

            Console.ReadLine();
        }
    }

    public static class Extensions
    {
        public static IEnumerable<Employee> FilterEmployees(this List<Employee> employees, Predicate<Employee> predicate)
        {
            foreach (Employee employee in employees)
            {
                if (predicate(employee))
                {
                    yield return employee;
                }
            }
        }
    }

    public sealed record Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public decimal Salary { get; set; }
        public char Gender { get; set; }
        public bool Manager { get; set; }
    }
}