using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Persistence.Configurations
{
    class LpmLoanProductSchemeMappingConfiguration : IEntityTypeConfiguration<LpmLoanProductSchemeMapping>
    {
        public void Configure(EntityTypeBuilder<LpmLoanProductSchemeMapping> builder)
        {
            builder
                .HasOne(b => b.LpmLoanSchemeMaster)
                .WithMany(b => b.LpmLoanProductSchemeMappings)
                .HasForeignKey(b => b.SchemeID)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(b => b.LpmLoanProductMaster)
                .WithMany(b => b.LpmLoanProductSchemeMappings)
                .HasForeignKey(b => b.ProductID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
