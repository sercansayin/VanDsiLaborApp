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
    internal class EmployeeConfiguration:IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.BirthDate).HasColumnType("nvarchar(10)");
            builder.Property(x => x.DateOfEmployment).HasColumnType("nvarchar(10)");
            builder.Property(x => x.TcNo).HasColumnType("nvarchar(11)").IsRequired();
            builder.Property(x => x.BirthPlace).HasColumnType("nvarchar(50)");
            builder.Property(x => x.SocialSecurityNumber).HasColumnType("nvarchar(50)");
            builder.Property(x => x.NameLastName).HasColumnType("nvarchar(75)");
            builder.Property(x => x.FirstLastName).HasColumnType("nvarchar(50)");
            builder.Property(x => x.FatherName).HasColumnType("nvarchar(50)");
            builder.Property(x => x.CreateDate).HasColumnType("datetime");
            builder.Property(x => x.UpdateDate).HasColumnType("datetime");
            builder.ToTable("Employees");
        }
    }
}
