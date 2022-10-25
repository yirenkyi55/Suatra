using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using MediatR;

using Suatra.Application.Common.Contracts.Services;
using Suatra.Application.Common.Exceptions;
using Suatra.Application.Common.Statics;
using Suatra.Application.Features.Auth.Dto.Requests;
using Suatra.Domain.Entities;

namespace Suatra.Application.Features.Auth.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest
    {
        public CreateAccountRequest CreateAccountRequest { get; }

        public CreateAccountCommand(CreateAccountRequest request)
        {
            CreateAccountRequest = request;
        }
    }

    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand>
    {
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;
        private readonly IApplicationMailService _applicationMailService;

        public CreateAccountCommandHandler(
            IIdentityService identityService,
            IMapper mapper,
            IApplicationMailService applicationMailService
            )
        {
            _identityService = identityService;
            _mapper = mapper;
            _applicationMailService = applicationMailService;
        }

        public async Task<Unit> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            // Check if user already exists
            if (await _identityService.FindUserByEmailAsync(request.CreateAccountRequest.Email) != null)
            {
                throw new BadRequestException("Account already exists");
            }

            var userEntity = _mapper.Map<User>(request.CreateAccountRequest);
            userEntity.UserName = request.CreateAccountRequest.Email;

            var (result, user) = await _identityService.CreateUserAsync(userEntity, request.CreateAccountRequest.Password);

            if (!result.Succeeded)
            {
                throw new ValidationException(result);
            }

            // Generate and Send an email activation token for the user
            var activationToken = await _identityService.GenerateEmailConfirmationTokenAsync(user);
            activationToken = TokenFormatter.EncodeToken(activationToken);
            await _applicationMailService.SendActivationTokenAsync(activationToken, user);

            return Unit.Value;
        }
    }
}