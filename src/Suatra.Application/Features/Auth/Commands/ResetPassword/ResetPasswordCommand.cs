using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Suatra.Application.Common.Contracts.Services;
using Suatra.Application.Common.Exceptions;
using Suatra.Application.Common.Models;
using Suatra.Application.Common.Statics;
using Suatra.Application.Features.Auth.Dto.Requests;
using Suatra.Application.Features.Auth.Dto.Responses;

namespace Suatra.Application.Features.Auth.Commands.ResetPassword
{
    public class ResetPasswordCommand: IRequest<(AuthUserResponse,string)>
    {
        public ResetPasswordRequest ResetPasswordRequest { get;  }

        public ResetPasswordCommand(ResetPasswordRequest request)
        {
            ResetPasswordRequest = request;
        }
    }

    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, (AuthUserResponse,string)>
    {
        private readonly IIdentityService _identityService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public ResetPasswordCommandHandler(
            IIdentityService identityService, 
            ITokenService tokenService,
            IMapper mapper)
        {
            _identityService = identityService;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        public async Task<(AuthUserResponse,string)> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _identityService.FindUserByEmailAsync(request.ResetPasswordRequest.Email);

            if (user == null)
            {
                throw new BadRequestException("User account does not exists");
            }

            var resetPasswordToken = TokenFormatter.DecodeToken(request.ResetPasswordRequest.Token);

            var result =
                await _identityService.ResetPasswordAsync(user, resetPasswordToken,
                    request.ResetPasswordRequest.Password);

            if (!result.Succeeded)
            {
                throw new ValidationException(result);
            }

            user.RefreshToken = _tokenService.GenerateRefreshToken();
            user.RefreshTokenExpiry = DateTime.Now.AddDays(ProjectHelper.RefreshTokenLength);

             result = await _identityService.UpdateUserAsync(user);

             if (!result.Succeeded)
             {
                 throw new ValidationException(result);
             }

             var userResponse = _mapper.Map<AuthUserResponse>(user);
             userResponse.AccessToken = _tokenService.GenerateAccessToken(user);

             return (userResponse, user.RefreshToken);
        }
    }
}