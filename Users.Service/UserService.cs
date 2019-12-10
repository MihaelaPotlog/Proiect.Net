using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Users.Domain.Models;
using Users.Domain.Repositories;
using Users.Service.DTOs;

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
            if (!MatchNames(request.FirstName))
                return "invalid first name";
            if (!MatchNames(request.LastName))
                return "invalid last name";
            string checkedEmail = CheckEmail(request.Email);
            if (checkedEmail.Equals("valid") != true)
                return checkedEmail;
            string checkedUserName = checkUsername(request.Username);
            if (checkedUserName.Equals("valid") != true)
                return checkedUserName;

            var currentUser = _userRepository.Add(request.FirstName, request.LastName, request.Username, request.Email, request.Password);
            _userRepository.AddUserTechnologyLinks(request.KnownTechnologies, currentUser);

            return "success";
        }

        public User ModifyUser(ModifyUserDto request)
        {
            User modifiedUser = _userRepository.Get(request.Id);

            if (IsValidUserData(request, modifiedUser) == false)
                return null;

            modifiedUser.Username = request.NewUsername;
            modifiedUser.FirstName = request.NewFirstName;
            modifiedUser.LastName = request.NewLastName;

            _userRepository.AddUserTechnologyLinks(request.AddedTechnologiesNames, modifiedUser);
            _userRepository.RemoveUserTechnologyLinks(request.RemovedTechnologiesNames, modifiedUser);


            return modifiedUser;
        }

        bool IsValidUserData(ModifyUserDto request, User modifiedUser)
        {
            if (modifiedUser == null)
            {
                return false;
            }

            //            ModifyUserValidator modifyUserValidator = new ModifyUserValidator();
            //            ValidationResult validationResult = modifyUserValidator.Validate(request);
            //
            //            if (validationResult.IsValid == false)
            //                return false;
            List<User> users = _userRepository.GetAll();
            foreach (User user in users)
            {
                if (user.Username == request.NewUsername && user.Id != request.Id)
                    return false;

            }

            return true;
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

        private string CheckEmail(string email)
        {
            if (!MatchEmail(email))
                return "invalid email";
            try
            {
                var exists = _userRepository.GetByEmail(email);
                if (exists != null)
                    return "email already in use";
                else
                    return "valid";
            }
            catch (ArgumentNullException)
            {
                return "valid";
            }
        }
        private string checkUsername(string username)
        {
            if (!MatchUserName(username))
                return "invalid username";

            try
            {
                var exists = _userRepository.GetByUsername(username);
                if (exists != null)
                    return "username already exists";
                else
                    return "valid";
            }
            catch (ArgumentNullException)
            {
                return "valid";
            }

        }
    }
}
