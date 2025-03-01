using MeterSystem.Domain.Entities;
using MeterSystem.Infrastructure;
using MeterSystem.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterSystem.Infrastructure.Repositories
{
    public class ConsumptionRepository : GenericRepository<Consumption>, IConsumptionRepository
    {
        public ConsumptionRepository(PostgreDbContext context) : base(context)
        {
        }
    }
}
