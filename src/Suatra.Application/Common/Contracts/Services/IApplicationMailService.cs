using System.Threading.Tasks;
using Suatra.Domain.Entities;

namespace Suatra.Application.Common.Contracts.Services
{
    public interface IApplicationMailService
    {
        Task<bool> SendActivationTokenAsync(string token, User user);
        Task<bool> SendPasswordResetTokenAsync(string token, User user);
    }
}