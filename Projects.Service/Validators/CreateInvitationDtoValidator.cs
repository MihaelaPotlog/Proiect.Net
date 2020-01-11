using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Projects.Domain.Models;
using Projects.Domain.Repositories;
using Projects.Service.Common;
using Projects.Service.DTOs;

namespace Projects.Service.Validators
{
    public class CreateInvitationDtoValidator : AbstractValidator<CreateInvitationDto>
    {

        private readonly IProjectRepository _projectRepository;

        public CreateInvitationDtoValidator(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
            RuleFor(dto => dto.CollaboratorId).MustAsync(NotBeCollaborator).WithMessage(ErrorMessages.AlreadyCollaborator);
            RuleFor(dto => dto.CollaboratorId).MustAsync(BeUniqueInvitation).WithMessage(ErrorMessages.InvitationExists);
        }

        private async Task<bool> NotBeCollaborator(CreateInvitationDto dto, Guid collaboratorId, CancellationToken cancellationToken)
        {
            if (await _projectRepository.GetProjectUser(dto.ProjectId, collaboratorId) != null)
                return false;
            return true;
        }

        private async Task<bool> BeUniqueInvitation(CreateInvitationDto dto, Guid collaboratorId, CancellationToken cancellationToken)
        {
            Project selectedProject = await _projectRepository.Get(dto.ProjectId, cancellationToken);
            Invitation selectedInvitation = await
                _projectRepository.GetInvitation(dto.ProjectId, dto.CollaboratorId,dto.OwnerId);

            if (selectedInvitation == null)
                return true;
            return false;
        }
    }
}
