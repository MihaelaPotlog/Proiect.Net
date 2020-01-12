namespace Users.Service.DTOs.ResponseDtos
{
    public class LoginResponseDto : IResponseDto
    {
        public bool Succeded { get; set; } = true;
        public UserDto User { get; set; }
        public Token Token { get; set; }


    }
}
