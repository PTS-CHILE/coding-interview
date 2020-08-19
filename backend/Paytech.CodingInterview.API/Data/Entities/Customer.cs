using Microsoft.EntityFrameworkCore;
using Paytech.CodingInterview.API.Data.Enumerators;

namespace Paytech.CodingInterview.API.Data.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public bool IsRemoved { get; set; }
        public CustomerStatusType Status { get; set; }

        public override void EntityMap(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers");
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Name).HasMaxLength(50).IsRequired();
                entity.Property(p => p.DocumentNumber).HasMaxLength(15).IsRequired();

                entity.HasOne(p => p.Category).WithMany(p => p.Customers).HasForeignKey(p => p.CategoryId);
            });
        }
    }
}
