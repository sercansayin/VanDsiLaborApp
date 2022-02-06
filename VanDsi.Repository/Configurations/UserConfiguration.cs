using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VanDsi.Core.Models;

namespace VanDsi.Repository.Configurations
{
    internal class UserConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreateDate).HasColumnType("datetime");
            builder.Property(x => x.UpdateDate).HasColumnType("datetime");
            builder.Property(x => x.IsDelete).HasColumnType("bit");
            builder.Property(x => x.RefleshToken).HasColumnType("nvarchar(100)");
            builder.Property(x => x.RefleshTokenAndDate).HasColumnType("datetime");
        }
    }
}
