using System;

namespace Suatra.Application.Common.Contracts.Persistence
{
    public interface IDatabaseTransaction : IDisposable
    {
        void Commit();

        void Rollback();
    }
}
