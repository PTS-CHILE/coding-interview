using Microsoft.EntityFrameworkCore;
using Paytech.CodingInterview.API.Data.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Paytech.CodingInterview.API.Data
{
    public class CodingInterviewContext : DbContext
    {
        protected CodingInterviewContext()
        {
        }

        public CodingInterviewContext(DbContextOptions<CodingInterviewContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) { }
        }
        
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            typeof(BaseEntity)
                .Assembly
                .GetTypes()
                .Where(t =>
                    t.IsSubclassOf(typeof(BaseEntity)) &&
                    !t.IsAbstract)
                .Select(t => Activator.CreateInstance(t) as BaseEntity)
                .ToList()
                .ForEach(p => p.EntityMap(modelBuilder));
        }
    }
}
