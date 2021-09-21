using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Moq;
using Shouldly;
using Suatra.Application.Common.Contracts.Services;
using Suatra.Application.Common.Exceptions;
using Suatra.Application.Features.Auth.Commands.CreateAccount;
using Suatra.Application.Features.Auth.Dto;
using Suatra.Application.Features.Auth.Dto.Requests;
using Suatra.Fixtures.Mocks;
using Xunit;

namespace Suatra.Application.Tests.Features.Auth.Commands
{
    public class CreateAccountCommandTests
    {
        private  IIdentityService _identityService;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;
        
        public CreateAccountCommandTests()
        {
            _identityService = IdentityServiceMock.GetMock().Object;
            _mailService = MailServiceMock.GetMock().Object;
            
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ShouldCreateAccountWithValidUser()
        {
            var fakeIdentityService = IdentityServiceMock.GetMock();
            fakeIdentityService.Setup(x => x.FindUserByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync(() => null);
            _identityService = fakeIdentityService.Object;
            
            var handler = new CreateAccountCommandHandler(_identityService, _mapper, _mailService);

            var request = new CreateAccountRequest
                {Email = "yirenemma@gmail.com", FirstName = "Emmanuel", LastName = "Yirenkyi", Password = "P@$$w0rd"};

          var response = await handler.Handle(new CreateAccountCommand(request),CancellationToken.None);
          response.ShouldBe(Unit.Value);
        }

        [Fact]
        public void Handle_ShouldThrowExceptionWithExistingUser()
        {
            var request = new CreateAccountRequest
                {Email = "yirenemma@gmail.com", FirstName = "Emmanuel", LastName = "Yirenkyi", Password = "P@$$w0rd"};

            var handler = new CreateAccountCommandHandler(_identityService, _mapper, _mailService);
            
            Should.Throw<BadRequestException>(async () => await handler.Handle(
                new CreateAccountCommand(request)  ,
                CancellationToken.None
            ));
        }
    }
}