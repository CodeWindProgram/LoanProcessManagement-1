using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Persistence.Configurations
{
    class LpmLeadProcessCycleConfiguration : IEntityTypeConfiguration<LpmLeadProcessCycle>
    {
        public void Configure(EntityTypeBuilder<LpmLeadProcessCycle> builder)
        {
            builder
              .HasOne(b => b.lead)
              .WithMany(b => b.LpmLeadProcessCycle)
              .OnDelete(DeleteBehavior.NoAction)
              .IsRequired()
              .HasForeignKey(b => b.lead_Id);

            builder
              .HasOne(b => b.LeadStatus)
              .WithMany(b => b.LpmLeadProcessCycle)
              .HasForeignKey(b => b.CurrentStatus)
              .OnDelete(DeleteBehavior.Cascade);

            builder
             .HasOne(b => b.LoanProduct)
             .WithMany(b => b.LoanProducts)
             .HasForeignKey(b => b.LoanProductID)
             .OnDelete(DeleteBehavior.Cascade);

            builder
             .HasOne(b => b.InsuranceProduct)
             .WithMany(b => b.InsuranceProducts)
             .HasForeignKey(b => b.InsuranceProductID)
             .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
