namespace ClubMembershipApplication.Models
{
    /// <summary>
    /// User dto
    /// </summary>
    public sealed record UserDto
    {
        public required string EmailAddress { get; set; } = null!;
        public required string FirstName { get; set; } = null!;
        public required string LastName { get; set; } = null!;
        public required string Password { get; set; } = null!;
        public required string PasswordCompare { get; set; } = null!;
        public required DateTime DateOfBirth { get; set; }
        public required string PhoneNumber { get; set; } = null!;
        public required string AddressFirstLine { get; set; } = null!;
        public string? AddressSecondLine { get; set; }
        public required string AddressCity { get; set; } = null!;
        public required string PostCode { get; set; } = null!;

        public static implicit operator UserDto(User user)
        {
            return new UserDto
            {
                EmailAddress = user.EmailAddress,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                PasswordCompare = null!,
                DateOfBirth = user.DateOfBirth,
                PhoneNumber = user.PhoneNumber,
                AddressFirstLine = user.AddressFirstLine,
                AddressSecondLine = user.AddressSecondLine,
                AddressCity = user.AddressCity,
                PostCode = user.PostCode
            };
        }
    }
}