using Microsoft.EntityFrameworkCore;
using Suatra.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Suatra.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public BaseRepository(ApplicationDbContext context)
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
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            return entity;
        }
    }
}
