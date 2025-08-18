using System.Collections.ObjectModel;

namespace EmployeeComponent
{
    public sealed class Employees : ObservableCollection<EmployeeViewModel>
    {
        public Employees() { }

        public static Employees Seed() => new()
        {
            EmployeeFactory.Create(1, "John", "Green", 40000, 'm'),
            EmployeeFactory.Create(2, "Sally", "Jones", 55000, 'f'),
            EmployeeFactory.Create(3, "Bill",  "Blog",  30000, 'm'),
            EmployeeFactory.Create(4, "Jamie","Hopkins",80000,'m'),
        };

        protected override void InsertItem(int index, EmployeeViewModel item)
        {
            // Esempio: blocca duplicati per Id
            if (this.Any(e => e.Id == item.Id))
            {
                throw new InvalidOperationException($"Employee {item.Id} già presente.");
            }

            base.InsertItem(index, item);
        }
    }
}