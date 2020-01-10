using System;
using System.Collections.Generic;

namespace Users.Domain.Models
{
    public class Technology
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public List<UserTechnology> UserTechnologies { get; private set; }

        private Technology()
        {
            Id = Guid.NewGuid();
            UserTechnologies = new List<UserTechnology>();
        }
        public static Technology CreateTechnology(string name)
        {
            return new Technology()
            {
                Name = name
            };
        }
    }
}
