using Moq;
using Suatra.Application.Common.Contracts.Services;
using Suatra.Domain.Entities;

namespace Suatra.Fixtures.Mocks
{
    public class MailServiceMock
    {
        public static Mock<IMailService> GetMock()
        {
            var mailServiceMock = new Mock<IMailService>();

            mailServiceMock.Setup(
                    x => x.SendActivationTokenAsync(
                        It.IsAny<string>(), It.IsAny<User>()))
                .ReturnsAsync(() => true);

            mailServiceMock.Setup(x => x.SendPasswordResetTokenAsync(
                    It.IsAny<string>(), It.IsAny<User>()))
                .ReturnsAsync(() => true);
            
            return mailServiceMock;
        }
    }
}