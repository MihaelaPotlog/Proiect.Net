using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Users.Service.DTOs
{
    public class ErrorResponseDto:IResponseDto
    {
        public IList<string> ErrorMessages { get; set; }
        public bool Succeded { get; set; } = false;

        public ErrorResponseDto(string errorMessage)
        {
            ErrorMessages = new List<string>() {errorMessage};
        }
        public ErrorResponseDto(IEnumerable<IdentityError> identityErrors)
        {
            ErrorMessages = new List<string>();
            foreach (IdentityError error in identityErrors)
            {
                ErrorMessages.Add(error.Description);
            }
        }
    }
}
