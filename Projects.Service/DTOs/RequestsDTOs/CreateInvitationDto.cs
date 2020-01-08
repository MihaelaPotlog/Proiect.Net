using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Service.DTOs
{
    public class CreateInvitationDto
    {
        public Guid ProjectId { get; set; }
        public Guid ReceiverId { get; set; }
    }
}
