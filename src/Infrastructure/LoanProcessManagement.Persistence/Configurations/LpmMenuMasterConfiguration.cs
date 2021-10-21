using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Persistence.Configurations
{
    public class LpmMenuMasterConfiguration : IEntityTypeConfiguration<LpmMenuMaster>
    {
        public void Configure(EntityTypeBuilder<LpmMenuMaster> builder)
        {
            //Not necessary if naming conventions are followed in model
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.ParentId)
                .HasColumnType("int");

            builder
                .Property(b => b.MenuName)
                .HasColumnType("nvarchar(500)")
                .IsRequired();

            builder
                .Property(b => b.Link)
                .HasColumnType("nvarchar(500)")
                .IsRequired();

            builder
                .Property(b => b.Icon)
                .HasColumnType("nvarchar(500)")
                .IsRequired();

            builder
                .Property(b => b.Position)
                .HasColumnType("int");
            
            builder
                .Property(b => b.IsActive)
                .HasColumnType("bit")
                .IsRequired();

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
        }
    }
}
