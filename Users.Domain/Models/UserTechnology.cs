using System;

namespace Users.Domain.Models
{
    public class UserTechnology
    {
        public Guid UserId { get; set; }
        public Guid TechnologyId { get; set; }
        public User User { get; set; }
        public Technology Technology { get; set; }

    }
}