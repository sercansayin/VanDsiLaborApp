using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VanDsi.Core.Models;

namespace VanDsi.Repository.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreateDate).HasColumnType("datetime");
            builder.Property(x => x.UpdateDate).HasColumnType("datetime");
            builder.Property(x => x.IsDelete).HasColumnType("bit");
            builder.Property(x => x.RefreshToken).HasColumnType("nvarchar(100)");
            builder.Property(x => x.RefreshTokenAndDate).HasColumnType("datetime");
        }
    }
}
