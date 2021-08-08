namespace Suatra.Application.Common.Contracts.Services
{
    public interface ISettingService
    {
        string GetClientUrl();
        
        string GetApiUrl();
    }
}