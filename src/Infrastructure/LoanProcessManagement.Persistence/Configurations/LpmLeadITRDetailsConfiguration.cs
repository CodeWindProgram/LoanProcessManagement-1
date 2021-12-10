using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Persistence.Configurations
{
    class LpmLeadITRDetailsConfiguration: IEntityTypeConfiguration<LpmLeadITRDetails>
    {
        public void Configure(EntityTypeBuilder<LpmLeadITRDetails> builder)
        {
            builder
            .HasOne(s => s.LeadApplicantDetails)
            .WithMany(s => s.LpmLeadITRDetails)
            .HasForeignKey(s => s.ApplicantDetailId);
        }
    }
}
