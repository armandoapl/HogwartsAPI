using HogwartsRegistration.Entities;
using Microsoft.EntityFrameworkCore;

namespace HogwartsRegistration.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext (DbContextOptions options) : base(options) { }

        public DbSet<InscriptionRequest> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<InscriptionRequest>()
                .HasIndex(ir => ir.HogwartsId)
                .IsUnique();
        }
       
    }
}
