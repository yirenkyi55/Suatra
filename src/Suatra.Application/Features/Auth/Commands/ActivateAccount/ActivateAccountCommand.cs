using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Suatra.Application.Common.Contracts.Services;
using Suatra.Application.Common.Exceptions;
using Suatra.Application.Common.Statics;
using Suatra.Application.Features.Auth.Dto.Requests;

namespace Suatra.Application.Features.Auth.Commands.ActivateAccount
{
    public class ActivateAccountCommand: IRequest
    {
        public ActivateAccountRequest ActivateAccountRequest { get; }

        public ActivateAccountCommand(ActivateAccountRequest request)
        {
            ActivateAccountRequest = request;
        }
    }

    public class ActivateAccountCommandHandler : IRequestHandler<ActivateAccountCommand>
    {
        private readonly IIdentityService _identityService;

        public ActivateAccountCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        
        public async Task<Unit> Handle(ActivateAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _identityService.FindUserByEmailAsync(request.ActivateAccountRequest.Email);

            if (user == null)
            {
                throw new BadRequestException("Unable to activate account");
            }

            string decodedToken;

            try
            {
                decodedToken = TokenFormatter.DecodeToken(request.ActivateAccountRequest.Token);
            }
            catch (Exception)
            {
                throw new BadRequestException("Unable to activate account");
            }

            var result = await _identityService.ConfirmEmailAsync(user, decodedToken);

            if (!result.Succeeded)
            {
                throw new ValidationException(result);
            }
            
            return  Unit.Value;

        }
    }
}