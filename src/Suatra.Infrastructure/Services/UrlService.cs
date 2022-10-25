using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Suatra.Application.Common.Configuration;
using Suatra.Application.Common.Contracts.Services;

namespace Suatra.Infrastructure.Services
{
    public class UrlService:IUrlService
    {
        private readonly ClientSettingOptions _clientSettings;

        public UrlService(IOptions<ClientSettingOptions> options)
        {
            _clientSettings = options.Value;
        }

        public string AppendUriQueryInfo(string endpoitnUri, IDictionary<string, string> queries)
        {
            return QueryHelpers.AddQueryString(endpoitnUri, queries);
        }

        public string GenerateAbsoluteUrl(string path)
        {
            var origin = _clientSettings.Host;
            var endpointUri = new UriBuilder(origin)
            {
                Path = path
            };

            return endpointUri.ToString();
        }
    }
}
