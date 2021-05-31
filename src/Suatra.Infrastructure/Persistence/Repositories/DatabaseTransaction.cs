using Microsoft.EntityFrameworkCore.Storage;
using Suatra.Application.Contracts.Persistence;

namespace Suatra.Infrastructure.Persistence.Repositories
{
    public class DatabaseTransaction : IDatabaseTransaction
    {
        private readonly IDbContextTransaction _transaction;

        public DatabaseTransaction(ApplicationDbContext context)
        {
            _transaction = context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }


        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose() => _transaction.Dispose();
    }
}
