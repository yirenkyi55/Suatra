using System.Threading.Tasks;

namespace Suatra.Application.Common.Contracts.Services
{
    public interface ITemplateService
    {
        Task<string> GetTemplateHtmlAsStringAsync<T>(string viewName, T model);
    }
}
