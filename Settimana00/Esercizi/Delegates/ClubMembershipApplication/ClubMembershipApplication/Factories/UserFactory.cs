using ClubMembershipApplication.Models;

namespace ClubMembershipApplication.Factories
{
    /// <summary>
    /// User factory
    /// </summary>
    public static class UserFactory
    {
        /// <summary>
        /// Factory method to map from UserDto to User
        /// </summary>
        /// <param name="dto"></param>
        /// <returns>a User</returns>
        public static User Map(UserDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto);

            var user = new User();
            user.SetEmailAddress(dto.EmailAddress);
            user.SetFirstName(dto.FirstName);
            user.SetLastName(dto.LastName);
            user.SetDateOfBirth(dto.DateOfBirth);
            user.SetPassword(dto.Password);
            user.SetPhoneNumber(dto.PhoneNumber);
            user.SetAddressFirstLine(dto.AddressFirstLine);
            user.SetAddressSecondLine(dto.AddressSecondLine);
            user.SetAddressCity(dto.AddressCity);
            user.SetPostCode(dto.PostCode);
            return user;
        }

        /// <summary>
        /// Factory method to map from UserDto to User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>a UserDto</returns>
        public static UserDto Map(User user)
        {
            ArgumentNullException.ThrowIfNull(user);

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
