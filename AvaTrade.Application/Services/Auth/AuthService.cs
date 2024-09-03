using AvaTrade.Domain.Entities.Users;
using AvaTrade.Infrastructure.Security.JWT;
using Microsoft.Extensions.Configuration;

namespace AvaTrade.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IConfiguration _configuration;
        private readonly TokenOptions? _tokenOptions;

        public AuthService(
            ITokenHelper tokenHelper,
            IConfiguration configuration
        )
        {
            _tokenHelper = tokenHelper;
            _configuration = configuration;
            _tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            AccessToken accessToken = _tokenHelper.CreateToken(user);
            return accessToken;
        }

        public Task<RefreshToken> CreateRefreshToken(User user)
        {
            RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user);
            return Task.FromResult(refreshToken);
        }
    }
}
