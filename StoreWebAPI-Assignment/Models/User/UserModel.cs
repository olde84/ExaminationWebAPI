namespace StoreWebAPI_Assignment.Models.User
{
    public class UserModel
    {
        public UserModel(int id, string firstName, string lastName, string emailAddress, string streetName, string zipcode, string city)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            StreetName = streetName;
            Zipcode = zipcode;
            City = city;
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string Zipcode { get; set; } = null!;
        public string City { get; set; }
    }
}
