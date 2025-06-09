using ClubMembershipApplication.FieldValitators;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubMembershipApplication.Models
{
    public sealed class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public required string EmailAddress { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string Password { get; private set; } = null!;
        public required DateTime DateOfBirth { get; set; }
        public required string PhoneNumber { get; set; }
        public required string AddressFirstLine { get; set; }
        public string? AddressSecondLine { get; set; }
        public required string AddressCity { get; set; }
        public required string PostCode { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        private User() { }

        /// <summary>
        /// Implicit operator
        /// </summary>
        /// <param name="dto"></param>
        public static implicit operator User(UserDto dto)
        {
            return new User
            {
                EmailAddress = dto.EmailAddress,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                PhoneNumber = dto.PhoneNumber,
                AddressFirstLine = dto.AddressFirstLine,
                AddressSecondLine = dto.AddressSecondLine,
                AddressCity = dto.AddressCity,
                PostCode = dto.PostCode
            };
        }

        /// <summary>
        /// CreateFrom (dto -> T)
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static User CreateFrom(UserDto dto)
        {
            if (!PasswordValidator.ArePasswordsMatching(dto))
                throw new ArgumentException("Passwords do not match");

            User user = dto;
            user.SetPassword(dto.Password);
            return user;
        }

        /// <summary>
        /// Sets the hashed password after validating input
        /// </summary>
        /// <param name="password"></param>
        public void SetPassword(string password)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(password);
            Password = PasswordValidator.HashPassword(password);
        }
    }
}
