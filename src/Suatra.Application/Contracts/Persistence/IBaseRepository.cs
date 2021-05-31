using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Suatra.Application.Contracts.Persistence
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);

        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> AddAsync(T entity);

        T Update(T entity);

        void Delete(T entity);

        IUnitOfWork UnitOfWork { get; }
    }
}
