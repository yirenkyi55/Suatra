using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NETCore.MailKit.Core;

namespace Suatra.Infrastructure.Services
{
    public class MailkitMailService:IMailService
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<MailkitMailService> _logger;

        public MailkitMailService(IEmailService emailService, ILogger<MailkitMailService> logger)
        {
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<bool> SendHtmlMailAsync(string recipientAddress, string subject, string htmlMessage)
        {
            try
            {
                await _emailService.SendAsync(recipientAddress, subject, htmlMessage, isHtml: true);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }

        public async Task<bool> SendMailAsync(string recipientAddress, string subject, string message)
        {
            try
            {
                await _emailService.SendAsync(recipientAddress, subject, message);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }
    }
}
