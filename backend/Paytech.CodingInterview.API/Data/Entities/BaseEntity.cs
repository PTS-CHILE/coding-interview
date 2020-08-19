using Microsoft.EntityFrameworkCore;
using System;

namespace Paytech.CodingInterview.API.Data.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        
        public DateTime CreationDate { get; set; }

        public abstract void EntityMap(ModelBuilder modelBuilder);
    }
}