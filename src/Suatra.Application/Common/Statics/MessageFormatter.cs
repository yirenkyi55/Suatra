using System;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using Suatra.Application.Common.Models;

namespace Suatra.Application.Common.Statics
{
    public static class MessageFormatter
    {
        public static string GenerateMailMessage(this HtmlMessage message)
        {
            var builder = new StringBuilder();
            builder.Append("<div style=\"border:1px solid #f93170; border-radius: 7px;padding: 10px;max-width: " +
                           "40%;background-color: #f0f0f0;position: absolute;transform: translate(-50%, -50%);left: 50%;top: 50%;\">");
            builder.Append($"<h2 style=\"color: #f93170; text-align: center;\">{message.Title}</h2>");
            builder.Append($"<p>Hey <strong>{message.User.FirstName.ToUpper()} {message.User.LastName.ToUpper()}!</strong>, {message.Header}</p>");
            builder.Append($"<p>{message.Message}</p>");
            builder.Append("<div><small>Please ignore this message if not intended for you!</small></div>");
            if (message.IncludeLinkButton)
            {
                builder.Append($"<a href=\"{message.Link}\" style=\"background-color: #8aadb2; color: #ccc;text-decoration: none;padding: 8px;margin: 10x;display: inline-block;border-radius: 7px;\">{message.LinkText}</a>");
            }

            builder.Append($"<p style=\"font-size: small; color: #f93170;\">Wisdom Encyclopedia &copy; {DateTime.Now.Year}</p>");
            builder.Append("</div>");
            return builder.ToString();
        }
    }
}