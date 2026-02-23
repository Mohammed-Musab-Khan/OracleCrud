using Microsoft.EntityFrameworkCore;
using OracleCrud.Models;

namespace OracleCrud.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        public DbSet<ReferenceData> ReferenceDataEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Oracle often works better if we explicitly define the schema/table
            modelBuilder.Entity<ReferenceData>(entity =>
            {
                entity.ToTable("REF_DATA_ENTRIES");
            });
        }
    }
}
