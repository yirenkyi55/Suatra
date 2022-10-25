using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Suatra.Application.Common.Contracts.Services;
using Suatra.Application.Common.Exceptions;
using Suatra.Application.Common.Statics;
using Suatra.Application.Features.Auth.Dto.Requests;

namespace Suatra.Application.Features.Auth.Queries.ResendActivation
{
    public class ResendActivationQuery: IRequest
    {
        public ResendActivationRequest ResendActivationRequest { get;  }

        public ResendActivationQuery(ResendActivationRequest resendActivationRequest)
        {
            ResendActivationRequest = resendActivationRequest;
        }
    }

    public class ResendActivationQueryHandler : IRequestHandler<ResendActivationQuery>
    {
        private readonly IIdentityService _identityService;
        private readonly IApplicationMailService _applicationMailService;

        public ResendActivationQueryHandler(IIdentityService identityService, IApplicationMailService applicationMailService)
        {
            _identityService = identityService;
            _applicationMailService = applicationMailService;
        }
        
        public async Task<Unit> Handle(ResendActivationQuery request, CancellationToken cancellationToken)
        {
            var user = await _identityService.FindUserByEmailAsync(request.ResendActivationRequest.Email);

            if (user == null)
            {
                throw new BadRequestException("Account not found");
            }
            
            // Generate and Send an email activation token for the user
            var activationToken = await _identityService.GenerateEmailConfirmationTokenAsync(user);
            activationToken = TokenFormatter.EncodeToken(activationToken);
            await _applicationMailService.SendActivationTokenAsync(activationToken, user);
            
            return Unit.Value;
        }
    }
}