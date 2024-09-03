using AvaTrade.Application.Common;
using AvaTrade.Application.Services.Auth;
using AvaTrade.Application.Services.Users;
using AvaTrade.Domain.Entities.Users;
using MediatR;

namespace AvaTrade.Application.Features.Authentication.Commands
{
    public record LoginCommand(string EmailOrUserName, string Password) : IRequest<LoginResponse>
    {
    }
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public LoginCommandHandler(
            IUserService userService,
            IAuthService authService
        )
        {
            _userService = userService;
            _authService = authService;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userService.GetByUserNameOrEmail(request.EmailOrUserName);

            if(user is null)
            {
                throw new ApiException("User does'not exist", System.Net.HttpStatusCode.NotFound);
            }

            LoginResponse loggedResponse = new();

            var createdAccessToken = await _authService.CreateAccessToken(user);

            var createdRefreshToken = await _authService.CreateRefreshToken(user);

            //delete old refresh tokens and add new refresh token

            loggedResponse.AccessToken = createdAccessToken.Token;

            loggedResponse.RefreshToken = createdRefreshToken.Token;

            return loggedResponse;
        }
    }
}
