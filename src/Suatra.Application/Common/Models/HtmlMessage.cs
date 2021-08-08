using Suatra.Domain.Entities;

namespace Suatra.Application.Common.Models
{
    public class HtmlMessage
    {
        public string Title { get; set; }

        public string Header { get; set; }

        public string Message { get; set; }

        public bool IncludeLinkButton { get; set; }

        public string Link { get; set; }

        public string LinkText { get; set; }

        public User User { get; set; }
    }
}