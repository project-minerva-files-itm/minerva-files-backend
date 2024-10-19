using Microsoft.EntityFrameworkCore;
using SharedLibrary.Data;
using SharedLibrary.Entities;
using System.Diagnostics.Metrics;

namespace SettingsService.Data
{
    public class DataContext : DbContext, IDataConext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }

        public DbSet<RequestType> RequestTypes { get; set; }

        public DbSet<ActivityState> ActivityStates { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<RequestType>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<ActivityState>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Department>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<DocumentType>().HasIndex(x => x.Name).IsUnique();
            DisableCascadingDelete(modelBuilder);
        }

        private void DisableCascadingDelete(ModelBuilder modelBuilder)
        {
            var relationships = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
            foreach (var relationship in relationships)
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public void AddEntity<T>(T entity) where T : class
        {
            Set<T>().Add(entity);
        }

        public void UpdateEntity<T>(T entity) where T : class
        {
            Set<T>().Update(entity);
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}