using System;

namespace Suatra.Application.Contracts.Persistence
{
    public interface IDatabaseTransaction : IDisposable
    {
        void Commit();

        void Rollback();
    }
}
