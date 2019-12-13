using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
            RuleFor(dto => dto.Email).Must(BeUniqueEmail).WithMessage("email already in use");

            RuleFor(dto => dto.Username).Must(MatchUserName).WithMessage("invalid username");
            RuleFor(dto => dto.Username).Must(BeUniqueUsername).WithMessage("username already exists");
            
            
            
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

        private bool BeUniqueEmail(string email)
        {
            try
            {
                var exists = UserRepository.GetByEmail(email);
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

        private bool BeUniqueUsername(string username)
        {
            try
            {
                var exists = UserRepository.GetByUsername(username);
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
