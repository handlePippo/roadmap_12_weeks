namespace ClubMembershipApplication.Models
{
    /// <summary>
    /// User dto
    /// </summary>
    public sealed record UserDto
    {
        public string EmailAddress { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PasswordCompare { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string AddressFirstLine { get; set; } = null!;
        public string? AddressSecondLine { get; set; }
        public string AddressCity { get; set; } = null!;
        public string PostCode { get; set; } = null!;
    }
}