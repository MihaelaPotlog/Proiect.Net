using System;
using Projects.Domain.Common;

namespace Projects.Domain.Models
{
    public class Invitation
    {
        public string Status { get; private set; }

        public Guid ProjectId { get; private set; }
        public Project Project { get; private set; }

        public Guid SenderId { get; private set; }
        public Guid ReceiverId { get; private set; }


        private Invitation()
        {
           
        }

        public static Invitation CreateInvitation( Guid projectId, Project project, Guid senderId, Guid receiverId)
        {

            return new Invitation()
            {
               
                Status = InvitationStatus.Pending,
                ProjectId = projectId,
                Project = project,
                SenderId = senderId,
                ReceiverId = receiverId
            };
        }

    }
}
