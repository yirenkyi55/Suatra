using Microsoft.EntityFrameworkCore;
using Suatra.Application.Common.Contracts.Persistence;
using Suatra.Application.Common.Specifications;
using Suatra.Domain.Common;
using Suatra.Infrastructure.Persistence.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<T> AddAsync(T entity)
        {
            return (await _context.Set<T>().AddAsync(entity)).Entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>()
                .Where(x => !x.IsInActive)
                .ToListAsync();
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

        private IQueryable<T> ApplySpec(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification);
        }
    }
}
