using MeterSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MeterSystem.Infrastructure
{
    public class PostgreDbContext : DbContext
    {
        public PostgreDbContext(DbContextOptions<PostgreDbContext> options) : base(options) { }
        public DbSet<Consumption> Consumptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consumption>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Consumption>()
                .HasIndex(c => c.CreatedAt)
                .HasAnnotation("Npgsql:IndexName", "idx_created_at");
        }

        public void EnsureHyperTable()
        {
            Database.ExecuteSqlRaw(@"CREATE EXTENSION IF NOT EXISTS timescaledb;");
        }

    }
}