using MeterSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterSystem.Infrastructure.Abstract
{
    public interface IConsumptionRepository : IRepository<Consumption>
    {
    }
}
