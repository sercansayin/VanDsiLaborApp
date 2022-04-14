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
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReferance)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReferance.CreateDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReferance).Property(x => x.CreateDate).IsModified = false;
                                entityReferance.UpdateDate = DateTime.Now;
                                break;
                            }
                    }
                }
                if (item.Entity is Labor entityLabor)
                {
                    switch (item.State)
                    {
                        case EntityState.Modified:
                            {
                                Entry(entityLabor).Property(x => x.EmployeeId).IsModified = false;
                                Entry(entityLabor).Property(x => x.UserId).IsModified = false;
                                break;
                            }
                    }
                }
            }


            //var entries = ChangeTracker.Entries().Where(e =>
            //    e.Entity is BaseEntity && e.State is EntityState.Added or EntityState.Modified);

            //foreach (var entityEntry in entries)
            //{
            //    ((BaseEntity)entityEntry.Entity).UpdateDate = DateTime.Now;
            //    if (entityEntry.State == EntityState.Added)
            //    {
            //        ((BaseEntity)entityEntry.Entity).CreateDate = DateTime.Now;
            //    }
            //}
        }
    }
}
