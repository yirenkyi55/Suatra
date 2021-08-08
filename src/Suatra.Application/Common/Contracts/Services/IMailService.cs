using System.Threading.Tasks;
using Suatra.Domain.Entities;

namespace Suatra.Application.Common.Contracts.Services
{
    public interface IMailService
    {
        Task<bool> SendActivationTokenAsync(string token, User user);
    }
}