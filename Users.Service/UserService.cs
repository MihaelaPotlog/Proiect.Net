using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Users.Domain.Models;
using Users.Domain.Repositories;
using Users.Service.DTOs;
using Users.Service.Validators;
using Users.Service.DTOs.ResponseDtos;


namespace Users.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IOptions<Audience> _settings;

        public UserService(IUserRepository userRepository, IOptions<Audience> settings, IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _settings = settings;
        }

        public async Task<IEnumerable<UserDto>> GetUsers(CancellationToken cancellationToken)
        {
            IEnumerable<User> users = await _userRepository.GetAllUsers(cancellationToken);
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
        public async Task<UserDto> GetUser(string id, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetUser(id, cancellationToken);
            return _mapper.Map<UserDto>(user);

        }
        public async Task<IEnumerable<Technology>> GetTechnologies(CancellationToken cancellationToken)
        {
            return await _userRepository.GetAllTechnologies(cancellationToken);
        }



        public async Task<IResponseDto> Login(LoginUserDto request, CancellationToken cancellationToken)
        {
            User currentUser = await _userRepository.GetByEmail(request.Email, cancellationToken);
            if (currentUser == null)
                return null;
            var signInResult = await _signInManager.PasswordSignInAsync(currentUser.UserName, password: request.Password, isPersistent: false, lockoutOnFailure: false);

            if (signInResult.Succeeded == false)
                return new ErrorMessagesDto(ErrorMessages.InvalidCredentials);
            else
                return new LoginResponseDto()
                {
                    Token = Token.CreateToken(currentUser.UserName, _settings.Value),
                    User = _mapper.Map<UserDto>(currentUser)
                };
        }

        public async Task<IResponseDto> Register(CreateUserDto request, CancellationToken cancellationToken)
        {
            var currentUser = User.UserFactory(request.Email, request.Username, request.FirstName, request.LastName);

            var result = await _userManager.CreateAsync(currentUser, request.Password);

            if (result.Succeeded == false)
                return new ErrorMessagesDto(result.Errors);

            await _userRepository.AddUserTechnologyLinks(request.KnownTechnologies, currentUser, cancellationToken);




            return new RegisterResponseDto();

        }


        public async Task<string> ModifyUser(ModifyUserDto request, CancellationToken cancellationToken)
        {
            User modifiedUser = await _userRepository.GetUser(request.Id, cancellationToken);
            if (modifiedUser == null)
                return "invalid id";
            ModifyUserDtoValidator modifyUserValidator = new ModifyUserDtoValidator(_userRepository);
            var validationResult = await modifyUserValidator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid == false)
                return validationResult.ToString();

            modifiedUser.FirstName = request.FirstName;
            modifiedUser.LastName = request.LastName;
            // modifiedUser.Username = request.Username;
            await _userRepository.Update(modifiedUser, cancellationToken);

            await _userRepository.AddUserTechnologyLinks(request.AddedTechnologiesNames, modifiedUser, cancellationToken);
            await _userRepository.RemoveUserTechnologyLinks(request.RemovedTechnologiesNames, modifiedUser, cancellationToken);

            return "success";
        }

    }
}