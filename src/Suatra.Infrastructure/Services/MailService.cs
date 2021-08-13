using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NETCore.MailKit.Core;
using Suatra.Application.Common.Contracts.Services;
using Suatra.Application.Common.Models;
using Suatra.Application.Common.Statics;
using Suatra.Domain.Entities;

namespace Suatra.Infrastructure.Services
{
    public class MailService: IMailService
    {
        private readonly IIdentityService _identityService;
        private readonly ISettingService _settingService;
        private readonly IEmailService _emailService;
        private readonly ILogger<MailService> _logger;

        public MailService(
            IIdentityService identityService,
            ISettingService settingService,
            IEmailService emailService,
            ILogger<MailService> logger
            )
        {
            _identityService = identityService;
            _settingService = settingService;
            _emailService = emailService;
            _logger = logger;
        }
        private async Task<bool> SendHtmlMailAsync(string recipientAddress, string subject, string htmlMessage)
        {
            try
            {
                await _emailService.SendAsync(recipientAddress, subject, htmlMessage, true);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"An error occured while sending email");
                return false;
            }
        }

        public async Task<bool> SendActivationTokenAsync(string token, User user)
        {

            var htmlMessage = new HtmlMessage
            {
                Title = "Activate your account",
                User = user,
                IncludeLinkButton = true,
                Header = "You successfully created a Suatra  Account",
                Message = "Please confirm your account by clicking on the below activation link",
                Link = $"{_settingService.GetClientUrl()}/auth/activate?token={token}&email={user.Email}",
                LinkText = "Activate Account"
            };

            return await SendHtmlMailAsync(
                user.Email,
                    "Activate your account", 
                htmlMessage.GenerateMailMessage());

        }

        public async Task<bool> SendPasswordResetTokenAsync(string token, User user)
        {
            var htmlMessage = new HtmlMessage
            {
                Title = "Reset Your Password",
                Link = $"{_settingService.GetClientUrl()}/auth/reset?token={token}&email={user.Email}",
                User = user,
                LinkText = "Reset Password",
                IncludeLinkButton = true,
                Message = "you requested to reset your password. <br/> You have 15 minutes to reset your password." +
                          " <div><p>Please reset your password by clicking on the link below</p></div>"
            };

            return await SendHtmlMailAsync(
                user.Email, 
                "Change your password", 
                htmlMessage.GenerateMailMessage());
            
        }
    }
}