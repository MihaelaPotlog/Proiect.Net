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
            RuleFor(dto => dto.ReceiverId).MustAsync(NotBeCollaborator).WithMessage(ErrorMessages.AlreadyCollaborator);
            RuleFor(dto => dto.ReceiverId).MustAsync(BeUniqueInvitation).WithMessage(ErrorMessages.InvitationExists);
        }

        private async Task<bool> NotBeCollaborator(CreateInvitationDto dto, Guid receiverId, CancellationToken cancellationToken)
        {
            if (await _projectRepository.GetProjectUser(dto.ProjectId, receiverId) != null)
                return false;
            return true;
        }

        private async Task<bool> BeUniqueInvitation(CreateInvitationDto dto, Guid receiverId, CancellationToken cancellationToken)
        {
            Project selectedProject = await _projectRepository.Get(dto.ProjectId, cancellationToken);
            Invitation selectedInvitation = await
                _projectRepository.GetInvitation(dto.ProjectId, selectedProject.OwnerId, dto.ReceiverId);

            if (selectedInvitation == null)
                return true;
            return false;
        }
    }
}
