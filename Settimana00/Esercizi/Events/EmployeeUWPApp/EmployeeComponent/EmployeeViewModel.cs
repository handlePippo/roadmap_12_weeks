using System.ComponentModel;

namespace EmployeeComponent
{
    public sealed class EmployeeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public int Id { get; set; }

        private string _firstName = null!;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (_firstName == value) return;
                _firstName = value;
                NotifyPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName { get; set; } = null!;
        public decimal AnnualSalary { get; set; }
        public char Gender { get; set; }
        public bool IsManager => AnnualSalary > 45000;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}