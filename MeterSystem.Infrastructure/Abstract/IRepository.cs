using MeterSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterSystem.Infrastructure.Abstract
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity?> GetById(int id);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(int id);
    }
}
