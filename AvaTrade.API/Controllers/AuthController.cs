using AvaTrade.API.Common;
using AvaTrade.Application.Features.Authentication.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AvaTrade.API.Controllers
{
    public class AuthController : BaseController
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            LoginResponse result = await Mediator.Send(command);

            return Ok(new ApiResponse<LoginResponse>(result));
        }
    }
}
