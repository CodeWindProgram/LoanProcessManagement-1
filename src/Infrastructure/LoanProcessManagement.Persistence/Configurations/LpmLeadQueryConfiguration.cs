using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Persistence.Configurations
{
    public class LpmLeadQueryConfiguration : IEntityTypeConfiguration<LpmLeadQuery>
    {
        public void Configure(EntityTypeBuilder<LpmLeadQuery> builder)
        {
            builder
            .HasOne(s => s.lead)
            .WithOne(s => s.leadquery)
            .HasForeignKey<LpmLeadQuery>(s => s.lead_Id);
        }
    }
}
