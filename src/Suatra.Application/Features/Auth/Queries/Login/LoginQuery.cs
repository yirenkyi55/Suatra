using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Suatra.Application.Common.Contracts.Services;
using Suatra.Application.Common.Exceptions;
using Suatra.Application.Common.Models;
using Suatra.Application.Features.Auth.Dto.Requests;
using Suatra.Application.Features.Auth.Dto.Responses;

namespace Suatra.Application.Features.Auth.Queries.Login
{
    public class LoginQuery:IRequest<(AuthUserResponse,string)>
    {
        public LoginRequest LoginRequest { get;  }

        public LoginQuery(LoginRequest request)
        {
            LoginRequest = request;
        }
    }

    public class LoginQueryHandler:IRequestHandler<LoginQuery, (AuthUserResponse,string)>
    {
        private readonly IIdentityService _identityService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public LoginQueryHandler(
            IIdentityService identityService,
            ITokenService tokenService,
            IMapper mapper)
        {
            _identityService = identityService;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        
        public async Task<(AuthUserResponse,string)> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var user = await _identityService.FindUserByEmailAsync(request.LoginRequest.Email);

            if (user == null)
            {
                throw new BadRequestException("Invalid email/password");
            }

            var isPasswordValid = await _identityService.CheckPasswordValidityAsync(user, request.LoginRequest.Password);

            if (!isPasswordValid)
            {
                throw new BadRequestException("Invalid email/password");
            }

            if (!user.EmailConfirmed)
            {
                throw new BadRequestException("Account has not been activated. Please confirm your email account");
            }

            user.RefreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshTokenExpiry = DateTime.Now.AddDays(ProjectHelper.RefreshTokenLength);

            var result = await _identityService.UpdateUserAsync(user);

            if (!result.Succeeded)
            {
                throw new ValidationException(result);
            }

            var userResponse = _mapper.Map<AuthUserResponse>(user);
            userResponse.AccessToken = _tokenService.GenerateAccessToken(user);
            

            return (userResponse,user.RefreshToken);
        }
    }
}