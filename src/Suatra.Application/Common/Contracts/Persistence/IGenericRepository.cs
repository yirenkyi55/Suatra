using Suatra.Application.Common.Specifications;
using Suatra.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Suatra.Application.Common.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : BaseEntity
    {

        Task<IReadOnlyList<T>> GetAllAsync();

        IQueryable GetEntity();

        Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> specification = null);
        
        IQueryable<T> GetEntityWithSpec(ISpecification<T> specification = null);

        Task<T> GetByIdAsync(Guid id);

        Task<T> GetEntityWithSpecAsync(ISpecification<T> specification);

        T Add(T entity);

        void AddRange(IEnumerable<T> entities);

        T Update(T entity);

        Task<int> CountWithSpecAsync(ISpecification<T> specification);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        int GetMaxRecord(Func<T, int> selector);
        
        Task SoftDeleteAsync(T entity);

        bool GetAny(Expression<Func<T, bool>> expression);
        IUnitOfWork UnitOfWork { get; }
    }
}
