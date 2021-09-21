using System;
using System.Threading;
using System.Threading.Tasks;

namespace Suatra.Application.Common.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IDatabaseTransaction BeginTransaction();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);
    }
}
