﻿using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Users.Domain.Repositories;
using Users.Service.DTOs;

namespace Users.Service.Validators
{
    class ModifyUserDtoValidator:AbstractValidator<ModifyUserDto>
    {
        private readonly IUserRepository UserRepository;

        public ModifyUserDtoValidator(IUserRepository userRepository)
        {
            UserRepository = userRepository;
            RuleFor(dto => dto.FirstName).Must(MatchNames).WithMessage("invalid first name");
            RuleFor(dto => dto.LastName).Must(MatchNames).WithMessage("invalid last name");

            RuleFor(dto => dto.Username).Must(MatchUserName).WithMessage("invalid username");
            RuleFor(dto => dto.Username).MustAsync(BeUniqueUsername).WithMessage("username already exists");
        }

        private bool MatchNames(string name)
        {
            string pattern = "^[A-Z]{1}[a-z]+";
            return Regex.IsMatch(name, pattern);
        }
        private bool MatchUserName(string username)
        {
            string pattern = "[A-Za-z0-9_-]+";
            return Regex.IsMatch(username, pattern);
        }

        private async Task<bool>  BeUniqueUsername(ModifyUserDto modifyRequest, string username, CancellationToken cancellationToken)
        {
            try
            {
                var exists = await UserRepository.GetByUsername(username, cancellationToken);
                
                if (exists != null && exists.Id != modifyRequest.Id)
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
