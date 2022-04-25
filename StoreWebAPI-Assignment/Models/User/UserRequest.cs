namespace StoreWebAPI_Assignment.Models.User
{
    public class UserRequest
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string Zipcode { get; set; } = null!;
        public string City { get; set; }
    }
}
