using AvaTrade.Domain.Entities.Users;

namespace AvaTrade.Application.Features.Authentication.Commands
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
