﻿using System;
using System.Collections.Generic;

namespace Projects.Domain.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get;  set; }
        public string Name { get;  set; }
        public string Description { get;  set; }
        public string State { get;  set; }

        public List<ProjectTechnology> ProjectTechnologies { get;  set; }
        public List<ProjectUser> ProjectUsers { get;  set; }
        public List<Invitation> Invitations { get; set; }


        private Project()
        {
            Id = Guid.NewGuid();
            ProjectTechnologies = new List<ProjectTechnology>();
            ProjectUsers = new List<ProjectUser>();
            Invitations = new List<Invitation>();
        }
        public static Project CreateProject(Guid ownerId,string name, string description, string state)
        {
            return new Project()
            {
                Name = name,
                Description = description,
                OwnerId = ownerId,
                State = state
            };
        }
    }
}
