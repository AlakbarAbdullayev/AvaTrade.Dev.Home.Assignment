using AvaTrade.Domain.Entities.Users;
using AvaTrade.Infrastructure.Security.JWT;

namespace AvaTrade.Application.Services.Auth
{
    public interface IAuthService
    {
        public Task<AccessToken> CreateAccessToken(User user);
        public Task<RefreshToken> CreateRefreshToken(User user);
    }
}
