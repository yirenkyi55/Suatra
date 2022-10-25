using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Extensions.Options;

using Suatra.Application.Common.Configuration;
using Suatra.Application.Common.Contracts.Services;
using Suatra.Application.Common.Models;
using Suatra.Domain.Entities;

namespace Suatra.Infrastructure.Services
{
    public class ApplicationMailService : IApplicationMailService
    {
        private readonly IMailService _mailService;
        private readonly ITemplateService _templateService;
        private readonly IUrlService _urlService;
        private readonly string _htmlViewTemplate = "Mails/MailTemplate";
        private readonly ClientSettingOptions _clientSettings;

        public ApplicationMailService(
            IMailService mailService,
            ITemplateService templateService,
            IOptions<ClientSettingOptions> options,
            IUrlService urlService)
        {
            _mailService = mailService;
            _templateService = templateService;
            _urlService = urlService;
            _clientSettings = options.Value;
        }

        public async Task<bool> SendActivationTokenAsync(string token, User user)
        {
            var endpointUri = _urlService.GenerateAbsoluteUrl(_clientSettings.AccountConfirmUrl);
            var activationLink = _urlService.AppendUriQueryInfo(endpointUri,
                new Dictionary<string, string> { { "token", token }, { "email", user.Email } });

            var htmlMessage = new HtmlMessage()
            {
                Title = "Activate your account",
                User = user,
                IncludeLinkButton = true,
                Header = "You successfully created a Suatra  Account",
                Message = "Please confirm your account by clicking on the below activation link",
                Link = activationLink,
                LinkText = "Activate Account"
            };

            var subject = "Activate Your Account";

            var viewTemplate = await _templateService
                .GetTemplateHtmlAsStringAsync(_htmlViewTemplate, htmlMessage);

            return await _mailService.SendHtmlMailAsync(user.Email, subject, viewTemplate);
        }

        public async Task<bool> SendPasswordResetTokenAsync(string token, User user)
        {
            var endpointUri = _urlService.GenerateAbsoluteUrl(_clientSettings.ResetPasswordUrl);
            var activationLink = _urlService.AppendUriQueryInfo(endpointUri,
                new Dictionary<string, string> { { "token", token }, { "email", user.Email } });

            var htmlMessage = new HtmlMessage
            {
                Title = "Reset Your Password",
                Link = activationLink,
                User = user,
                LinkText = "Reset Password",
                IncludeLinkButton = true,
                Message = "You requested to reset your password. You have 15 minutes to do so."
            };

            var subject = "Reset Your Password";

            var viewTemplate = await _templateService
                .GetTemplateHtmlAsStringAsync(_htmlViewTemplate, htmlMessage);

            return await _mailService.SendHtmlMailAsync(user.Email, subject, viewTemplate);
        }
    }
}