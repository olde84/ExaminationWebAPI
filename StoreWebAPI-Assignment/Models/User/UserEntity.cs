using System.ComponentModel.DataAnnotations;

namespace StoreWebAPI_Assignment.Models.User
{
    public class UserEntity
    {
        public UserEntity()
        {
        }

        public UserEntity(int id, string firstName, string lastName, string emailAddress, string password, string streetName, string zipcode, string city)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            Password = password;
            StreetName = streetName;
            Zipcode = zipcode;
            City = city;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public string EmailAddress { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public string StreetName { get; set; } = null!;

        [Required]
        public string Zipcode { get; set; } = null!;

        [Required]
        public string City { get; set; } = null!;

    }
}
