using System;
using System.Collections.Generic;
using System.Text;

namespace Users.Domain.Models
{
    public class Technologie
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public List<UserTechnologie> UserTechnologies { get; private set; }

        private Technologie()
        {
            Id = Guid.NewGuid();
            UserTechnologies = new List<UserTechnologie>();
        }
        public static Technologie CreateTechnologie(string name)
        {
            return new Technologie()
            {
                Name = name
            };
        }
    }
}
