using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Persistence.Configurations
{
    class LpmCibilCheckConfiguration : IEntityTypeConfiguration<LpmCibilCheckDetails>
    {
        public void Configure(EntityTypeBuilder<LpmCibilCheckDetails> builder)
        {
            builder
            .HasOne(s => s.LeadApplicantDetails)
            .WithMany(s => s.LpmCibilCheckDetails)
            .HasForeignKey(s => s.ApplicantDetailId);
        }
    }
}
