using Microsoft.Extensions.Options;
using Suatra.Application.Common.Contracts.Services;
using Suatra.Application.Common.Models;

namespace Suatra.Infrastructure.Services
{
    public class SettingService: ISettingService
    {
        private readonly Settings _settings;
        
        public SettingService(IOptions<Settings> options)
        {
            _settings = options.Value;
        }
        
        public string GetClientUrl()
        {
            return _settings.ClientUrl;
        }

        public string GetApiUrl()
        {
            return _settings.ApiUrl;
        }
    }
}