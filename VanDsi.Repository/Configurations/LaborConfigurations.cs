using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VanDsi.Core.Models;

namespace VanDsi.Repository.Configurations
{
    internal class LaborConfigurations : IEntityTypeConfiguration<Labor>
    {
        public void Configure(EntityTypeBuilder<Labor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Winnings).HasColumnType("decimal(19,2)");
            builder.Property(x => x.WorkPlaceNumber).HasColumnType("varchar(15)");
            builder.Property(x => x.CreateDate).HasColumnType("datetime");
            builder.Property(x => x.UpdateDate).HasColumnType("datetime");
            builder.ToTable("Labors");
            builder.HasOne(x => x.Employee).WithMany(x => x.Labors).HasForeignKey(x => x.EmployeeId);
        }
    }
}
