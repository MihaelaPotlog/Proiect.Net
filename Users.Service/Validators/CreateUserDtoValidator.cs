using FluentValidation;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Users.Domain.Repositories;
using Users.Service.DTOs;

namespace Users.Service.Validators
{
    class CreateUserDtoValidator:AbstractValidator<CreateUserDto>
    {
        private readonly IUserRepository UserRepository;

        public CreateUserDtoValidator(IUserRepository userRepository)
        {
            UserRepository = userRepository;
            RuleFor(dto => dto.FirstName).Must(MatchNames).WithMessage("invalid first name");
            RuleFor(dto => dto.LastName).Must(MatchNames).WithMessage("invalid last name");

            RuleFor(dto => dto.Email).Must(MatchEmail).WithMessage("invalid email");
            RuleFor(dto => dto.Email).MustAsync(BeUniqueEmail).WithMessage("email already in use");

            RuleFor(dto => dto.Username).Must(MatchUserName).WithMessage("invalid username");
            RuleFor(dto => dto.Username).MustAsync(BeUniqueUsername).WithMessage("username already exists");
            
            
            
        }
        private bool MatchNames(string name)
        {
            string pattern = "^[A-Z]{1}[a-z]+";
            return Regex.IsMatch(name, pattern);
        }
        private bool MatchEmail(string email)
        {
            string pattern = ".+@[a-z0-9]+.[a-z]+";
            return Regex.IsMatch(email, pattern);
        }
        private bool MatchUserName(string username)
        {
            string pattern = "[A-Za-z0-9_-]+";
            return Regex.IsMatch(username, pattern);
        }

        private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
        {
            try
            {
                var exists = await UserRepository.GetByEmail(email, cancellationToken);
                if (exists != null)
                    return false;
                else
                    return true;
            }
            catch (ArgumentNullException)
            {
                return true;
            }
        }

        private async Task<bool> BeUniqueUsername(string username, CancellationToken cancellationToken)
        {
            try
            {
                var exists = await UserRepository.GetByUsername(username, cancellationToken);
                if (exists != null)
                    return false;
                else
                    return true;
            }
            catch (ArgumentNullException)
            {
                return true;
            }
        }


    }
}
