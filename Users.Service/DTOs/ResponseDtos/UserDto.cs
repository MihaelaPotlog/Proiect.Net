namespace Users.Service.DTOs
{
    public class UserDto
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; internal set; }
        public string Username { get; set; }
        public string[] KnownTechnologies { get; set; }
        
    }
}
