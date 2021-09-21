using Moq;
using Suatra.Application.Common.Contracts.Services;
using Suatra.Application.Common.Models;
using Suatra.Domain.Entities;

namespace Suatra.Fixtures.Mocks
{
    public class IdentityServiceMock
    {
        
        public  static Mock<IIdentityService> GetMock()
        {
            var fakeIdentityService = new Mock<IIdentityService>();
            
            fakeIdentityService.Setup(
                x =>
                    x.CreateUserAsync(It.IsAny<User>(), It.IsAny<string>())
            ).ReturnsAsync(() => (Result.Success(), new User() {Email = "sam@gmail.com"}));

            fakeIdentityService.Setup(x => x.FindUserByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync(() => new User());

            fakeIdentityService.Setup(x =>
                    x.GenerateEmailConfirmationTokenAsync(It.IsAny<User>()))
                .ReturnsAsync(() => "fake token");

            return fakeIdentityService;
        }
    }
}