using System;

namespace Projects.Service.DTOs
{
    public class CreateInvitationDto
    {
        public Guid ProjectId { get; set; }
        public Guid ReceiverId { get; set; }
    }
}
