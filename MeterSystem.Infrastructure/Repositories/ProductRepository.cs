using MeterSystem.Domain.Abstract;
using MeterSystem.Domain.Entities;
using MeterSystem.Infrastructure.Abstract;
using Microsoft.EntityFrameworkCore;

namespace MeterSystem.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private PostgreDbContext _context;

        public ProductRepository(PostgreDbContext context) : base(context)
        {
            this._context = context;
        }
        public async Task<Product> Create(Product entity)
        {
            bool exists = await _context.Set<Product>().AnyAsync(e => e.Code == entity.Code);
            if (exists)
            {
                throw new Exception("Product exists!!");
            }
            _ = _context.Set<Product>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Set<Product>().Include(e => e.Consumptions).AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
