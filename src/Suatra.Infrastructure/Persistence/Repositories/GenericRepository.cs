using Microsoft.EntityFrameworkCore;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Application.Common.Specifications;
using Suatra.Domain.Common;
using Suatra.Infrastructure.Persistence.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Suatra.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public T Add(T entity)
        {
            return ( _context.Set<T>().Add(entity)).Entity;
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>()
                .Where(x => !x.IsInActive)
                .ToListAsync();
        }

        public IQueryable GetEntity()
        {
            return _context.Set<T>();
        }

        public  IQueryable<T> GetEntityWithSpec(ISpecification<T> specification = null)
        {
           return ApplySpec(specification);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>()
                .Where(x => !x.IsInActive)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public async Task SoftDeleteAsync(T entity)
        {
            var result = await GetByIdAsync(entity.Id);
            result.IsInActive = true;
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> specification = null)
        {
            var result = ApplySpec(specification);

            return await result.ToListAsync();
        }

        public async Task<T> GetEntityWithSpecAsync(ISpecification<T> specification)
        {
            return await ApplySpec(specification).FirstOrDefaultAsync();
        }

        public async Task<int> CountWithSpecAsync(ISpecification<T> specification)
        {
            return await ApplySpec(specification).CountAsync();
        }

        public  int GetMaxRecord(Func<T, int> selector)
        {
            return _context.Set<T>().Max(selector);
        }
        
        public bool GetAny(Expression<Func<T, bool>> expression)
        {
            return  _context.Set<T>().Any(expression);
        }

        private IQueryable<T> ApplySpec(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification);
        }
        
         
    }
}
