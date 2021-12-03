using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Persistence.Configurations
{
    public class LpmUserRoleMenuMapConfiguration : IEntityTypeConfiguration<LpmUserRoleMenuMap>
    {
        public void Configure(EntityTypeBuilder<LpmUserRoleMenuMap> builder)
        {
            //Not necessary if naming conventions are followed in model
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.UserRoleId)
                .IsRequired()
                .HasColumnType("bigint");

            builder
                .Property(b => b.MenuId)
                .IsRequired()
                .HasColumnType("bigint");

            builder
                .HasOne(b => b.UserRole)
                .WithMany(b => b.LpmUserRoleMenuMaps)
                .HasForeignKey(b => b.UserRoleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(b => b.MenuName)
                .WithMany(b => b.LpmUserRoleMenuMaps)
                .HasForeignKey(b => b.MenuId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(b => b.CreatedBy)
                .HasColumnType("nvarchar(500)");

            builder
                .Property(b => b.CreatedDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder
                .Property(b => b.LastModifiedBy)
                .HasColumnType("nvarchar(500)");

            builder
                .Property(b => b.LastModifiedDate)
                .HasColumnType("datetime");

            builder
                .Property(b => b.IsActive)
                .HasColumnType("bit")
                .IsRequired();
        }
    }
}
