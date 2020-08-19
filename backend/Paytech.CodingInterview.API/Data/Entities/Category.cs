using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Paytech.CodingInterview.API.Data.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public bool IsRemoved { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }

        public override void EntityMap(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Name).HasMaxLength(50).IsRequired();
            });
        }
    }
}