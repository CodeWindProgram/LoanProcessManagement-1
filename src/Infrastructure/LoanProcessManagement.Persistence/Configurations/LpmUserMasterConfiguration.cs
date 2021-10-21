using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Persistence.Configurations
{
    public class LpmUserMasterConfiguration : IEntityTypeConfiguration<LpmUserMaster>
    {
        public void Configure(EntityTypeBuilder<LpmUserMaster> builder)
        {
            //Not necessary if naming conventions are followed in model
            //builder
            //    .HasKey(b => b.EventId);

            //builder
            //    .Property(b => b.CreatedBy)
            //    .HasColumnType("nvarchar(450)");

            //builder
            //    .Property(b => b.LastModifiedBy)
            //    .HasColumnType("nvarchar(450)");

            //builder
            //    .Property(b => b.Name)
            //    .HasColumnType("nvarchar(50)")
            //    .IsRequired();

            //builder
            //    .Property(b => b.Artist)
            //    .HasColumnType("nvarchar(50)")
            //    .IsRequired();

            //builder
            //    .Property(b => b.Description)
            //    .HasColumnType("nvarchar(500)")
            //    .IsRequired();

            //builder
            //    .Property(b => b.ImageUrl)
            //    .HasColumnType("nvarchar(200)")
            //    .IsRequired();

            //Not necessary if relationship conventions are followed in model(Cascade is the default behaviour)
            builder
                .HasOne(b => b.UserRole)
                .WithMany(b => b.LpmUserMasters)
                .HasForeignKey(b=>b.UserRoleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(b => b.Branch)                
                .WithMany(b => b.LpmUserMasters)
                .HasForeignKey(b => b.BranchId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
