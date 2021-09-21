using System.Threading.Tasks;
using Suatra.Domain.Entities;

namespace Suatra.Application.Common.Contracts.Services
{
    public interface ICurrentUserService
    {
        string GetLoggedInUserEmail();

    }
}