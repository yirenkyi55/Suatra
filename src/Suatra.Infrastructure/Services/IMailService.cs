using System.Threading.Tasks;

namespace Suatra.Infrastructure.Services
{
    public  interface IMailService
    {
        Task<bool> SendHtmlMailAsync(string recipientAddress, string subject, string htmlMessage);

        Task<bool> SendMailAsync(string recipientAddress, string subject, string message);
    }
}
