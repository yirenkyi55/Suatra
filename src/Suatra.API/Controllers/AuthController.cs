using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Suatra.Application.Common.Exceptions;
using Suatra.Application.Features.Auth.Commands.ActivateAccount;
using Suatra.Application.Features.Auth.Commands.CreateAccount;
using Suatra.Application.Features.Auth.Commands.RefreshToken;
using Suatra.Application.Features.Auth.Commands.ResetPassword;
using Suatra.Application.Features.Auth.Dto.Requests;
using Suatra.Application.Features.Auth.Dto.Responses;
using Suatra.Application.Features.Auth.Queries.ForgotPassword;
using Suatra.Application.Features.Auth.Queries.Login;
using Suatra.Application.Features.Auth.Queries.ResendActivation;

namespace Suatra.API.Controllers
{
    [Route("api/v{version:apiVersion}/auth")]
    public class AuthController: BaseController
    {
        private const string RefreshTokenCookieName = "token_refresh";

        [HttpPost("account")]
        [AllowAnonymous]
        public async Task<ActionResult> CreateAccount(CreateAccountRequest request)
        {
             await Mediator.Send(new CreateAccountCommand(request));
             return Ok();
        }

        [HttpPost("activate")]
        [AllowAnonymous]
        public async Task<ActionResult> ActivateAccount(ActivateAccountRequest request)
        {
            await Mediator.Send(new ActivateAccountCommand(request));
            return Ok();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthUserResponse>> Login(LoginRequest request)
        {
            var (userResponse, refreshToken) = await Mediator.Send(new LoginQuery(request));
            AppendRefreshTokenToResponseCookie(refreshToken);
            return Ok(userResponse);
        }

        [HttpPost("forgotPassword")]
        [AllowAnonymous]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordRequest request)
        {
            var result = await Mediator.Send(new ForgotPasswordQuery(request));
            return Ok(result);
        }
        
        [HttpPost("resetPassword")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthUserResponse>> ResetPassword(ResetPasswordRequest request)
        {
            var (user,refreshToken) = await Mediator.Send(new ResetPasswordCommand(request));
            AppendRefreshTokenToResponseCookie(refreshToken);
            return Ok(user);
        }

        [HttpPost("resendActivation")]
        [AllowAnonymous]
        public async Task<ActionResult> ResendActivation(ResendActivationRequest request)
        {
             await Mediator.Send(new ResendActivationQuery(request));
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<ActionResult<AuthUserResponse>> RefreshToken(RefreshTokenRequest request)
        {
            if (!Request.Cookies.TryGetValue(RefreshTokenCookieName, out string refreshToken))
            {
                throw new UnauthorizedException("Unauthorized");
            }

            var (authUserResponse, refresh) = await Mediator.Send(new RefreshTokenCommand(request, refreshToken));

            AppendRefreshTokenToResponseCookie(refresh);
            return Ok(authUserResponse);
        }

        private void AppendRefreshTokenToResponseCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            
            Response.Cookies.Append(RefreshTokenCookieName, token,cookieOptions);
        }
    }
}