using System;
using Projects.Domain.Common;

namespace Projects.Domain.Models
{
    public class Invitation
    {
        public string Status { get; private set; }
        public int InvitationType { get; private set; }

        public Guid ProjectId { get; private set; }
        public Project Project { get; private set; }

        public Guid CollaboratorId { get; private set; }
        public Guid OwnerId { get; private set; }


        private Invitation()
        {
           
        }

        public static Invitation CreateInvitation( Guid projectId, Project project, Guid CollaboratorId, Guid OwnerId, int invitationType)
        {

            return new Invitation()
            {
               
                Status = InvitationStatus.Pending,
                ProjectId = projectId,
                Project = project,
                CollaboratorId = CollaboratorId,
                OwnerId = OwnerId,
                InvitationType = invitationType
            };
        }

    }
}
