namespace Users.Domain.Models
{
    public class UserTechnology
    {
        public string UserId { get; set; }
        public string TechnologyId { get; set; }
        public User User { get; set; }
        public Technology Technology { get; set; }

    }
}