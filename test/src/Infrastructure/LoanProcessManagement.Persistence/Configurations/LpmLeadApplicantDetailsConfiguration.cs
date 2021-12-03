﻿using Microsoft.EntityFrameworkCore;
using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Persistence.Configurations
{
    class LpmLeadApplicantDetailsConfiguration : IEntityTypeConfiguration<LpmLeadApplicantsDetails>
    {
        public void Configure(EntityTypeBuilder<LpmLeadApplicantsDetails> builder)
        {

            builder
                .HasOne(b => b.LpmLeadMaster)
                .WithMany(b => b.LpmLeadApplicantsDetails)
                .HasForeignKey(b => b.lead_Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}