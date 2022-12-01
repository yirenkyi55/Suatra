using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Suatra.Application.Common.Contracts.Services;
using Suatra.Application.Common.Exceptions;
using Suatra.Application.Features.Auth.Dto.Requests;
using Suatra.Application.Features.Auth.Dto.Responses;

namespace Suatra.Application.Features.Auth.Commands.RefreshToken;

public class RefreshTokenCommand : IRequest<(AuthUserResponse userResponse, string refreshToken)>
{
    public RefreshTokenRequest RefreshTokenRequest { get; }
    public string RefreshToken { get; }

    public RefreshTokenCommand(RefreshTokenRequest refreshTokenRequest, string refreshToken)
    {
        RefreshTokenRequest = refreshTokenRequest;
        RefreshToken = refreshToken;
    }
}

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, (AuthUserResponse userResponse, string accessToken)>
{
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    private readonly IIdentityService _identityService;

    public RefreshTokenCommandHandler(
        ITokenService tokenService,
        IMapper mapper,
        IIdentityService identityService)
    {
        _tokenService = tokenService;
        _mapper = mapper;
        _identityService = identityService;
    }

    public async Task<(AuthUserResponse userResponse, string accessToken)> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var claimsPrincipal = _tokenService.GeneratePrincipalFromExpiredToken(request.RefreshTokenRequest.Token);
        if (claimsPrincipal == null)
        {
            throw new UnauthorizedException("Invalid access token");
        }

        var email = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        
        var user = await _identityService.FindUserByEmailAsync(email);
        if (user == null || user.RefreshToken != request.RefreshToken ||
            user.RefreshTokenExpiry < DateTimeOffset.UtcNow)
        {
            throw new UnauthorizedException("Unauthorized");
        }

        user.RefreshToken = _tokenService.GenerateRefreshToken();
        user.PasswordResetTokenExpiry = DateTimeOffset.UtcNow.AddDays(30);

        await _identityService.UpdateUserAsync(user);

        var authUser = _mapper.Map<AuthUserResponse>(user);
        authUser.AccessToken = _tokenService.GenerateAccessToken(user);

        return (authUser, user.RefreshToken);
    }
}