using Microsoft.EntityFrameworkCore;
using System;

namespace Paytech.CodingInterview.API.Data.Entities
{
    public class ExternalProduct : BaseEntity
    {
        public int ExternalReferenceId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool IsRemoved { get; set; }

        public override void EntityMap(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExternalProduct>(entity =>
            {
                entity.ToTable("ExternalProducts");
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Name).HasMaxLength(100).IsRequired();
                entity.Property(p => p.Code).HasMaxLength(50).IsRequired();
            });
        }
    }
}
