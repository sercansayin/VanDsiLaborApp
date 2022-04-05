using System.Reflection;
using Microsoft.EntityFrameworkCore;
using VanDsi.Core.Models;
using VanDsi.Repository.Configurations;

namespace VanDsi.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Labor> Labors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //IEntityTypeConfiguration' implemente eden bütün çalışılan clasları ekle anlamında
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //tek tek eklemek istersek aşağıdaki gibi
            modelBuilder.ApplyConfiguration(new LaborConfigurations());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            SetBaseEntity();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            SetBaseEntity();
            return base.SaveChangesAsync(cancellationToken);
        }


        private void SetBaseEntity()
        {
            var entries = ChangeTracker.Entries().Where(e =>
                e.Entity is BaseEntity && e.State is EntityState.Added or EntityState.Modified);

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdateDate = DateTime.Now;
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreateDate = DateTime.Now;
                }
            }
        }
    }
}
