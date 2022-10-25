using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Suatra.Application.Common.Contracts.Services;
using Suatra.Application.Common.Exceptions;
using Suatra.Application.Common.Statics;
using Suatra.Application.Features.Auth.Dto.Requests;

namespace Suatra.Application.Features.Auth.Queries.ForgotPassword
{
    public class ForgotPasswordQuery: IRequest
    {
        public ForgotPasswordRequest ForgotPasswordRequest { get;  }

        public ForgotPasswordQuery(ForgotPasswordRequest request)
        {
            ForgotPasswordRequest = request;
        }
    }

    public class ForgotPasswordQueryHandler : IRequestHandler<ForgotPasswordQuery>
    {
        private readonly IIdentityService _identityService;
        private readonly IApplicationMailService _applicationMailService;

        public ForgotPasswordQueryHandler(
            IIdentityService identityService,
            IApplicationMailService applicationMailService)
        {
            _identityService = identityService;
            _applicationMailService = applicationMailService;
        }
        
        public async Task<Unit> Handle(ForgotPasswordQuery request, CancellationToken cancellationToken)
        {
            var user = await _identityService.FindUserByEmailAsync(request.ForgotPasswordRequest.Email);

            if (user == null)
            {
                return Unit.Value;
            }

            var resetToken = await _identityService.GeneratePasswordResetToken(user);
            resetToken = TokenFormatter.EncodeToken(resetToken);

            var result = await _applicationMailService.SendPasswordResetTokenAsync(resetToken, user);

            if (!result)
            {
                throw new BadRequestException("An error occured whiles sending email. Please try again later");
            }
            
            return Unit.Value;
        }
    }
}