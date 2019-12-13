using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Users.Domain.Models;
using Users.Domain.Repositories;
using Users.Service.DTOs;
using Users.Service.Validators;

namespace Users.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetAll();
        }

        public User LoginUser(LoginUserDto request)
        {
            var EmailToCheck = request.Email;
            var PasswordToCheck = request.Password;
            var addr = new EmailAddressAttribute();

            if (addr.IsValid(EmailToCheck))
            {
                var foundUser = _userRepository.GetByEmail(EmailToCheck);
                if (PasswordToCheck == foundUser.Password)
                    return foundUser;
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        public string RegisterUser(CreateUserDto request)
        {
            CreateUserDtoValidator dtoValidator = new CreateUserDtoValidator(_userRepository);
            var result = dtoValidator.Validate(request);

            if (result.IsValid == true)
            {
                var currentUser = _userRepository.Add(request.FirstName, request.LastName, request.Username,
                    request.Email, request.Password);
                _userRepository.AddUserTechnologyLinks(request.KnownTechnologies, currentUser);

                return "success";
            }

            return result.ToString();
        }

        public string ModifyUser(ModifyUserDto request)
        {
            User modifiedUser = _userRepository.Get(request.Id);

            if (modifiedUser == null)
            {
                return "empthy body";
            }


            ModifyUserDtoValidator modifyUserValidator = new ModifyUserDtoValidator(_userRepository);
            var validationResult = modifyUserValidator.Validate(request);

            if (validationResult.IsValid == false)
                return validationResult.ToString();

            
            // _userRepository.Update();
            _userRepository.AddUserTechnologyLinks(request.AddedTechnologiesNames, modifiedUser);
            _userRepository.RemoveUserTechnologyLinks(request.RemovedTechnologiesNames, modifiedUser);


            return "success";
        }
    }
}