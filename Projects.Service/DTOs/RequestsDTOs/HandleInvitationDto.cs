using System;

namespace Projects.Service.DTOs.RequestsDTOs
{
    public class HandleInvitationDto
    {
        public Guid ProjectId { get; set; }
        public Guid OwnerId { get; set; }
        public Guid CollaboratorId { get; set; }
        public int Accepted { get; set; }

    }
}
