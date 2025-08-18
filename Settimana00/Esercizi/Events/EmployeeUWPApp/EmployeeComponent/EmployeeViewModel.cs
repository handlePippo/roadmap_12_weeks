using System.ComponentModel;

namespace EmployeeComponent
{
    public sealed class EmployeeViewModel : INotifyPropertyChanged
    {
        private const uint LIMIT_MANAGER = 45000;
        public int Id { get; private init; }

        private string _firstName = null!;
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName == value) return;
                _firstName = value;
                NotifyPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName { get; private init; } = null!;
        public decimal AnnualSalary { get; private init; }
        public char Gender { get; private init; }
        public bool IsManager => AnnualSalary > LIMIT_MANAGER;

        public event PropertyChangedEventHandler? PropertyChanged;
        public EmployeeViewModel(int id, string firstName, string lastName, decimal annualSalary, char gender)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            AnnualSalary = annualSalary;
            Gender = gender;
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}