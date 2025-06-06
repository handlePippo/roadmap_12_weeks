using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClubMembershipApplication.Models
{
    public sealed class User
    {
        private string _password = null!;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Password { get => _password; set => _password = Convert.ToBase64String(Encoding.UTF8.GetBytes(value)); }
        public required string AddressCity { get; set; }
        public required string AddressFirstLine { get; set; }
        public string? AddressSecondLine { get; set; }
        public required string PostCode { get; set; }
    }
}