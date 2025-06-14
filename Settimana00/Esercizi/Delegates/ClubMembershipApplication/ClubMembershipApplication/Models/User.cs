using ClubMembershipApplication.Validators;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClubMembershipApplication.Models
{
    public sealed class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        public string EmailAddress { get; private set; } = null!;
        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;
        public string Password { get; private set; } = null!;
        public DateTime DateOfBirth { get; private set; }
        public string PhoneNumber { get; private set; } = null!;
        public string AddressFirstLine { get; private set; } = null!;
        public string? AddressSecondLine { get; private set; }
        public string AddressCity { get; private set; } = null!;
        public string PostCode { get; private set; } = null!;

        /// <summary>
        /// Constructor
        /// </summary>
        public User() { }

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
                Password = dto.Password,
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

        public void SetEmailAddress(string emailAddress)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(emailAddress);
            EmailAddress = emailAddress;
        }

        public void SetFirstName(string firstName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(firstName);
            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(lastName);
            LastName = lastName;
        }

        public void SetPassword(string password)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(password);
            Password = PasswordValidator.HashPassword(password);
        }

        public void SetDateOfBirth(DateTime dateOfBirth)
        {
            DateOfBirth = dateOfBirth;
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(phoneNumber);
            PhoneNumber = phoneNumber;
        }

        public void SetAddressFirstLine(string addressFirstLine)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(addressFirstLine);
            AddressFirstLine = addressFirstLine;
        }

        public void SetAddressSecondLine(string? addressSecondLine)
        {
            AddressSecondLine = addressSecondLine;
        }

        public void SetAddressCity(string addressCity)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(addressCity);
            AddressCity = addressCity;
        }
        public void SetPostCode(string postCode)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(postCode);
            PostCode = postCode;
        }
    }
}
