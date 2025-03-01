using MeterSystem.Domain.Entities;
using MeterSystem.Infrastructure;
using MeterSystem.Infrastructure.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterSystem.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly PostgreDbContext _context;
        public GenericRepository(PostgreDbContext context)
        {
            _context = context;
        }
        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }
        public async Task<TEntity?> GetById(int id)
        {
            return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<TEntity> Create(TEntity entity)
        {
            _ = _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<TEntity> Delete(int id)
        {
            var entity = await GetById(id);
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
