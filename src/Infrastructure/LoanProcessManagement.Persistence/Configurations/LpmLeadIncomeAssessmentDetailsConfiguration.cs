using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Persistence.Configurations
{
    class LpmLeadIncomeAssessmentDetailsConfiguration : IEntityTypeConfiguration<LpmLeadIncomeAssessmentDetails>
    {
        public void Configure(EntityTypeBuilder<LpmLeadIncomeAssessmentDetails> builder)
        {
            builder
            .HasOne(s => s.LeadApplicantDetails)
            .WithMany(s => s.LpmLeadIncomeAssessmentDetails)
            .HasForeignKey(s => s.ApplicantDetailId);
        }
    }
}
