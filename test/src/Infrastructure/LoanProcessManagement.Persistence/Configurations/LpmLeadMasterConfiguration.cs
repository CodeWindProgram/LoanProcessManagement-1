using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Persistence.Configurations
{
    public class LpmLeadMasterConfiguration : IEntityTypeConfiguration<LpmLeadMaster>
    {
        public void Configure(EntityTypeBuilder<LpmLeadMaster> builder)
        {
            builder
                .HasOne(b => b.Branch)
                .WithMany(b => b.LpmLeadMasters)
                .HasForeignKey(b => b.BranchID)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(b => b.Product)
                .WithMany(b => b.LpmLeadMasters)
                .HasForeignKey(b => b.ProductID)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(b => b.LeadStatus)
                .WithMany(b => b.LpmLeadMasters)
                .HasForeignKey(b => b.CurrentStatus)
                .OnDelete(DeleteBehavior.Cascade);


            builder
                .HasOne(b => b.PropertyTypes)
                .WithMany(b => b.LpmLeadMaster)
                .HasForeignKey(b => b.PropertyID)
                .OnDelete(DeleteBehavior.Cascade);



            builder
                .HasOne(b => b.SanctionedPlans)
                .WithMany(b => b.LpmLeadMaster)
                .HasForeignKey(b => b.IsSanctionedPlanReceivedID)
                .OnDelete(DeleteBehavior.Cascade);


            builder
                .HasOne(b => b.LoanSchemes)
                .WithMany(b => b.LpmLeadMasters)
                .HasForeignKey(b => b.SchemeID)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
