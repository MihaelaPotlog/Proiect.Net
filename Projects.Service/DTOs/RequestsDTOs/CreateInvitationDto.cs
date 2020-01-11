using System;

namespace Projects.Service.DTOs
{
    public class CreateInvitationDto
    {
        public Guid ProjectId { get; set; }
        public Guid CollaboratorId { get; set; }
        public Guid OwnerId { get; set; }
        public int InvitationType { get; set; }

    }
}
