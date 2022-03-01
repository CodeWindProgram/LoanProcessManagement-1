using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Persistence.Configurations
{
    class LPMGSTEnquiryDetailConfiguration : IEntityTypeConfiguration<LPMGSTEnquiryDetail>
    {
        public void Configure(EntityTypeBuilder<LPMGSTEnquiryDetail> builder)
        {
            builder
            .HasOne(b => b.LeadApplicantDetails)
            .WithMany(b => b.LPMGSTEnquiryDetails)
            .HasForeignKey(b => b.ApplicantDetailId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
