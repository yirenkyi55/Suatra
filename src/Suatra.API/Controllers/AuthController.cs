using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Suatra.Application.Features.Auth.Commands.ActivateAccount;
using Suatra.Application.Features.Auth.Commands.CreateAccount;
using Suatra.Application.Features.Auth.Commands.ResetPassword;
using Suatra.Application.Features.Auth.Dto.Requests;
using Suatra.Application.Features.Auth.Dto.Responses;
using Suatra.Application.Features.Auth.Queries.ForgotPassword;
using Suatra.Application.Features.Auth.Queries.Login;

namespace Suatra.API.Controllers
{
    [Route("api/v{version:apiVersion}/auth")]
    public class AuthController: BaseController
    {
        [HttpPost("account")]
        public async Task<ActionResult> CreateAccount(CreateAccountRequest request)
        {
             await Mediator.Send(new CreateAccountCommand(request));
             return Ok();
        }

        [HttpPost("activate")]
        public async Task<ActionResult> ActivateAccount(ActivateAccountRequest request)
        {
            await Mediator.Send(new ActivateAccountCommand(request));
            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthUserResponse>> Login(LoginRequest request)
        {
            var (userResponse, refreshToken) = await Mediator.Send(new LoginQuery(request));
            SetTokenCookie(refreshToken);
            return Ok(userResponse);
        }

        [HttpPost("forgotPassword")]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordRequest request)
        {
            var result = await Mediator.Send(new ForgotPasswordQuery(request));
            return Ok(result);
        }
        
        [HttpPost("resetPassword")]
        public async Task<ActionResult<AuthUserResponse>> ResetPassword(ResetPasswordRequest request)
        {
            var (user,refreshToken) = await Mediator.Send(new ResetPasswordCommand(request));
            SetTokenCookie(refreshToken);
            return Ok(user);
        }

        private void SetTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            
            Response.Cookies.Append("refresh_token",token,cookieOptions);
        }
    }
}