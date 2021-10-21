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
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.EmployeeId)
                .HasColumnType("nvarchar(500)")
                .IsRequired();

            builder
                .Property(b => b.LgId)
                .HasColumnType("nvarchar(500)")
                .IsRequired();

            builder
                .Property(b => b.Name)
                .HasColumnType("nvarchar(500)")
                .IsRequired();

            builder
                .Property(b => b.Email)
                .HasColumnType("nvarchar(500)")
                .IsRequired();

            builder
                .Property(b => b.Password)
                .HasColumnType("nvarchar(500)")
                .IsRequired();

            builder
                .Property(b => b.SaltKey)
                .HasColumnType("nvarchar(500)")
                .IsRequired();

            builder
                .Property(b => b.StaffType)
                .HasColumnType("nvarchar(500)");

            builder
                .Property(b => b.BranchId)
                .HasColumnType("bigint")
                .IsRequired();

            builder
                .Property(b => b.SaleType)
                .HasColumnType("nvarchar(500)");

            builder
                .Property(b => b.PhoneNumber)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder
                .Property(b => b.UserRoleId)
                .HasColumnType("bigint")
                .IsRequired();

            builder
                .Property(b => b.VerificationCode)
                .HasColumnType("nvarchar(500)");

            builder
                .Property(b => b.LeadCount)
                .HasColumnType("int");

            builder
                .Property(b => b.WrongLoginAttempt)
                .HasColumnType("int");

            builder
                .Property(b => b.IsLocked)
                .HasColumnType("bit")
                .IsRequired();

            builder
                .Property(b => b.IsActive)
                .HasColumnType("bit")
                .IsRequired();

            builder
                .Property(b => b.LastLogin)
                .HasColumnType("datetime");

            builder
                .Property(b => b.ActivatedOn)
                .HasColumnType("datetime");

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
