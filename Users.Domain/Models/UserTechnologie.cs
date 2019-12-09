using System;

namespace Users.Domain.Models
{
    public class UserTechnologie
    {
        public Guid UserId { get; set; }
        public Guid TechnologieId { get; set; }
        public User User { get; set; }
        public Technologie Technologie { get; set; }

    }
}