using MeterSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MeterSystem.Infrastructure
{
    public static class TimeScaleExtensions
    {
        public static void ApplyHypertables(this DbContext context)
        {
            //adding timescale extension to the database
            context.Database.ExecuteSqlRaw("CREATE EXTENSION IF NOT EXISTS timescaledb CASCADE;");
            var entityTypes = context.Model.GetEntityTypes();
            foreach (var entityType in entityTypes)
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.PropertyInfo.GetCustomAttribute(typeof(HypertableColumnAttribute)) != null)
                    {

                        var tableName = entityType.GetTableName();
                        var columnName = property.GetColumnName();
                        context.Database.ExecuteSqlRaw($"SELECT create_hypertable('\"{tableName}\"', '{columnName}')\r\nWHERE NOT EXISTS (SELECT 1 FROM timescaledb_information.hypertables WHERE hypertable_name = '{tableName}');");
                    }
                }
            }
        }
    }
}
