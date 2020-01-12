using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.Service.DTOs.RequestsDTOs
{
   public class ResponseInvitationDTO
    {
        public string Status { get;  set; }
        public int InvitationType { get;  set; }

        public Guid ProjectId { get;  set; }
        public string ProjectName { get;  set; }

        public Guid CollaboratorId { get;  set; }
        public Guid OwnerId { get;  set; }
    }
}
